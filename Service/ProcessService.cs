using OpenCvSharp;
using OpenCvSharp.Features2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VP_QM_winform.ComManager;
using VP_QM_winform.Controller;
using VP_QM_winform.DTO;
using VP_QM_winform.Service;
using VP_QM_winform.Helper;
using VP_QM_winform.VO;

namespace VP_QM_winform.Service
{
    public class ProcessService
    {
        private readonly ArduinoController _arduinoController;
        private readonly CameraController _cameraController;
        private readonly VisionController _visionController;
        private readonly MQTTManager _MQTTManager;
        private VisionCumVO _visionCumVO;

        private CancellationTokenSource _cancellationTokenSource;

        
        public ProcessService()
        {
            string brokerAddress = "43.203.159.137";
            string username = "admin";
            string password = "vapor";
            int port = 1883;
            _arduinoController = new ArduinoController();
            ProcessState.UpdateState("ArduinoConnected", true);
            _arduinoController.LampOn("GREEN", onOff: true);

            _cameraController = new CameraController();
            ProcessState.UpdateState("CameraConnected", true);
            _visionController = new VisionController();
            _MQTTManager = new MQTTManager(brokerAddress, port, username, password);
        }

        public async Task RunAsync()
        {

            Console.WriteLine("Run 호출");

            MQTTDTO dto = new MQTTDTO
            {
                LineId = "Line001",
                LotId = Global.s_CurrentLot,
                Shift = Global.s_LoginDTO.Employee.Shift,
                EmployeeNumber = Global.s_LoginDTO.User.EmployeeNumber
            };

            // 새 CancellationTokenSource 생성
            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = _cancellationTokenSource.Token;

            // 상태 초기화
            ProcessState.UpdateState("CurrentStage", "waiting");
            
            
            ProcessState.UpdateState("MQTTConnected", false);        

            try
            {
               

                // 초기화 대기
                _arduinoController.StartSerialReadThread();
                _arduinoController.ResetPosition();

                //타워램프 RED
                _arduinoController.LampOn("GREEN", onOff: false);
                _arduinoController.LampOn("RED", onOff: true);

                // MQTT 연결 상태 확인
                if (_MQTTManager.IsConnected)
                {
                    ProcessState.UpdateState("MQTTConnected", true);
                }
                else
                {
                    throw new InvalidOperationException("MQTT 연결 실패");
                }

                while (true)
                {
                    // 작업이 취소되었는지 확인
                    token.ThrowIfCancellationRequested();
                    
                    //센서 1
                    if (_arduinoController.serialReceiveData.Contains("PS_3=ON"))
                    {
                        ProcessState.UpdateState("CurrentStage", "sensor1");
                        Console.WriteLine($"현재 stage: {ProcessState.GetState("CurrentStage")}");

                        _arduinoController.serialReceiveData = "";
                        _arduinoController.SendConveyorSpeed(200);
                        Console.WriteLine("물건 투입");
                        //MQTT 전송
                        dto.StageVal = "100";
                        try
                        {
                            await _MQTTManager.PublishMessageAsync(dto);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"MQTT 메시지 발행 중 오류 발생: {ex.Message}");
                        }

                        
                    }
                    //센서2 && 비전검사 이벤트
                    if (_arduinoController.serialReceiveData.Contains("PS_2=ON"))
                    {
                        ProcessState.UpdateState("CurrentStage", "sensor2");
                        Console.WriteLine($"현재 stage: {ProcessState.GetState("CurrentStage")}");

                        _arduinoController.serialReceiveData = "";
                        await Task.Delay(1000, token); // 작업 취소 가능 대기
                        _arduinoController.SendConveyorSpeed(0);
                        await Task.Delay(2000, token);

                        Console.WriteLine("비전 검사 시작");
                        Mat img = await _cameraController.CaptureAsync(); // 비동기로 캡처
                        //ProcessImage에서 비전처리된 img를 dto의 NGImg 프로퍼티에 set
                        await Task.Run(() => _visionController.ProcessImage(img,dto), token); // 비동기로 처리

                        var inspectionResult = ProcessState.GetState("InspectionResult");
                        Console.WriteLine($"판독 결과: {inspectionResult}");
                        await Task.Delay(2000, token); // 이미지 처리 대기


                        //MQTT 전송
                        dto.StageVal = "010";
                        try
                        {
                            await _MQTTManager.PublishMessageAsync(dto);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"MQTT 메시지 발행 중 오류 발생: {ex.Message}");
                        }
                        // img 초기화
                        img.Dispose();
                        _arduinoController.SendConveyorSpeed(200);

                        
                    }
                    // 센서3 이벤트 처리
                    if (_arduinoController.serialReceiveData.Contains("PS_1=ON"))
                    {
                        bool inspectionResult = (bool)ProcessState.GetState("InspectionResult");
                        Console.WriteLine($"{inspectionResult}");
                        ProcessState.UpdateState("CurrentStage", "sensor3");
                        Console.WriteLine($"현재 stage: {ProcessState.GetState("CurrentStage")}");

                        _arduinoController.serialReceiveData = "";
                        _visionCumVO = new VisionCumVO()
                        {
                            LineId = "vp1",
                            Time = DateTime.Now,
                            LotId = Global.s_CurrentLot,
                            Shift = Global.s_LoginDTO.Employee.Shift,
                            EmployeeNumber = Global.s_LoginDTO.User.EmployeeNumber,
                            Total = Global.s_VisionCumList.Count + 1
                        };
                        Global.s_VisionCumList.Add(_visionCumVO);
                        
                        // MQTT 메시지 전송
                        dto.StageVal = "001";
                        try
                        {
                            await _MQTTManager.PublishMessageAsync(dto);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"MQTT 메시지 발행 중 오류 발생: {ex.Message}");
                        }

                        // DB 쿼리 전송
                        VisionCumService visionCumService = new VisionCumService();
                        try
                        {
                            visionCumService.InsertVision(_visionCumVO);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("DB Insert 실패 : processService");
                        }

                        if (!inspectionResult) // 검사 결과가 Bad인 경우
                        {
                            _arduinoController.SendConveyorSpeed(0);
                            await Task.Delay(2000, token);

                            // FlashLamp 실행 (노란색 램프 켜기)
                           _arduinoController.FlashLamp("YELLOW", true);

                            // 불량품 처리 로직
                            await Task.Run(() => _arduinoController.GrabObj(), token);
                            await Task.Delay(2000, token);

                            await Task.Run(() => _arduinoController.PullObj(), token);
                            await Task.Delay(2000, token);

                            await Task.Run(() => _arduinoController.MovToBad(), token);
                            await Task.Delay(2000, token);

                            await Task.Run(() => _arduinoController.DownObj(), token);
                            await Task.Delay(2000, token);

                            // 초기화 작업
                            _arduinoController.ResetPosition();
                            await _arduinoController.FlashLamp("YELLOW", false);

                            // 상태 전환: Idle
                            ProcessState.UpdateState("CurrentStage", "waiting");
                            _arduinoController.LampOn("RED", onOff: false);
                            _arduinoController.LampOn("GREEN", onOff: true);
                            Console.WriteLine("불량품 처리 완료, 대기 상태로 전환");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
            finally
            {
                // 자원 정리 및 상태 초기화
                _arduinoController.ResetPosition();
                await _MQTTManager.DisconnectAsync();
                ProcessState.UpdateState("MQTTConnected", false);

                ProcessState.UpdateState("CurrentStage", "Idle");
                _arduinoController.LampOn("RED", onOff: false);
                _arduinoController.LampOn("GREEN", onOff:true);
                Console.WriteLine($"현재 stage: {ProcessState.GetState("CurrentStage")}");
            }
        }

        public void Stop()
        {
            try
            {
                Console.WriteLine("작업 중단 요청");

                // CancellationTokenSource를 취소하여 실행 중인 작업 중단
                _cancellationTokenSource?.Cancel();

                // Arduino 상태 초기화
                _arduinoController.ResetPosition();

                // MQTT 연결 해제
                _MQTTManager?.DisconnectAsync().Wait(); // 동기적으로 해제

                // 램프 상태 초기화
                _arduinoController.LampOn("RED", onOff: false);
                _arduinoController.LampOn("GREEN", onOff: true);

                // 현재 상태를 Idle로 설정
                ProcessState.UpdateState("CurrentStage", "Idle");
                Console.WriteLine($"현재 stage: {ProcessState.GetState("CurrentStage")}");

                Console.WriteLine("작업이 안전하게 중단되었습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"작업 중단 중 오류 발생: {ex.Message}");
            }

        }
    }
}
