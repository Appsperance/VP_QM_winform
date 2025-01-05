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

namespace VP_QM_winform.Service
{
    public class ProcessService
    {
        private readonly ArduinoController _arduinoController;
        private readonly CameraController _cameraController;
        private readonly VisionController _visionController;
        private readonly MQTTManager _MQTTManager;

        private CancellationTokenSource _cancellationTokenSource;

        private bool isGood { get; set; }

        MQTTDTO dto = new MQTTDTO
        {
            LineId = "Line001",
            LotId = "Lot123",
            Shift = "Day",
            EmployeeNumber = "E12345"
        };
        public ProcessService()
        {
            string brokerAddress = "43.203.159.137";
            string username = "admin";
            string password = "vapor";
            int port = 1883;
            _arduinoController = new ArduinoController();
            _cameraController = new CameraController();
            _visionController = new VisionController();
            _MQTTManager = new MQTTManager(brokerAddress, port, username, password);
        }

        public async Task RunAsync()
        {
            Console.WriteLine("Run 호출");

            // 새 CancellationTokenSource 생성
            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = _cancellationTokenSource.Token;

            // 상태 초기화
            ProcessState.UpdateState("CurrentStage", "waiting");
            ProcessState.UpdateState("ArduinoConnected", false);
            ProcessState.UpdateState("CameraConnected", false);
            ProcessState.UpdateState("MQTTConnected", false);        

            try
            {
                // Arduino 연결
                if (await _arduinoController.ConnectToArduinoUnoAsync() && _arduinoController.IsConnected)
                {
                    ProcessState.UpdateState("ArduinoConnected", true);
                    _arduinoController.StartSerialReadThread();
                }
                else
                {
                    throw new InvalidOperationException("Arduino 연결 실패");
                }

                // 초기화 대기
                _arduinoController.ResetPosition();
                await Task.Delay(2000, token);

                // Camera 연결 확인
                _cameraController.Connect();
                if (_cameraController.IsConnected)
                {
                    ProcessState.UpdateState("CameraConnected", true);
                }
                else
                {
                    throw new InvalidOperationException("카메라 연결 실패");
                }

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
                    //비전검사 이벤트
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
                    //로봇팔 이벤트
                    if (_arduinoController.serialReceiveData.Contains("PS_1=ON") &&
                        (bool)ProcessState.GetState("InspectionResult")==false)
                    {
                        ProcessState.UpdateState("CurrentStage", "sensor3");
                        Console.WriteLine($"현재 stage: {ProcessState.GetState("CurrentStage")}");

                        _arduinoController.serialReceiveData = "";
                        _arduinoController.SendConveyorSpeed(0);
                        await Task.Delay(2000, token);

                        dto.StageVal = "001";
                        try
                        {
                            await _MQTTManager.PublishMessageAsync(dto);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"MQTT 메시지 발행 중 오류 발생: {ex.Message}");
                        }


                        await Task.Run(() => _arduinoController.GrabObj(), token);
                        await Task.Delay(2000, token);

                        await Task.Run(() => _arduinoController.PullObj(), token);
                        await Task.Delay(2000, token);

                        await Task.Run(() => _arduinoController.MovToBad(), token);
                        await Task.Delay(2000, token);

                        await Task.Run(() => _arduinoController.DownObj(), token);
                        await Task.Delay(2000, token);

                        _arduinoController.ResetPosition();
                        // 상태 전환: Idle
                        ProcessState.UpdateState("CurrentStage", "waiting");
                        Console.WriteLine("불량품 처리 완료, 대기 상태로 전환");
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
                _arduinoController.CloseConnection();
                ProcessState.UpdateState("ArduinoConnected", false);

                _cameraController.Dispose();
                ProcessState.UpdateState("CameraConnected", false);

                await _MQTTManager.DisconnectAsync();
                ProcessState.UpdateState("MQTTConnected", false);

                ProcessState.UpdateState("CurrentStage", "Idle");
                Console.WriteLine($"현재 stage: {ProcessState.GetState("CurrentStage")}");
            }
        }

        public void StopAsync()
        {
            if (_cancellationTokenSource != null)
            {
                Console.WriteLine("작업 중단 요청됨...");
                _cancellationTokenSource.Cancel(); // 작업 취소 요청
            }
        }
    }
}
