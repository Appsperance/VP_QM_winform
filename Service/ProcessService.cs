using OpenCvSharp;
using System;
using System.Threading;
using System.Threading.Tasks;
using VP_QM_winform.ComManager;
using VP_QM_winform.Controller;
using VP_QM_winform.DTO;
using VP_QM_winform.Helper;
using VP_QM_winform.VO;

namespace VP_QM_winform.Service
{
    public class ProcessService
    {
        private readonly ArduinoController _arduinoController;
        private string ArduinoPort {  get; set; }

        private readonly CameraController _cameraController;
        private readonly VisionController _visionController;
        private readonly MQTTManager _MQTTManager;
        private VisionCumVO _visionCumVO;
        private VisionHistoryDTO _visionHistoryDTO;
        private VPBusManager _busManager;
        private VisionNgService _visionNgService;

        private CancellationTokenSource _cancellationTokenSource;

        public static bool mytoken;
        
        public ProcessService()
        {
            _arduinoController = new ArduinoController();
            _cameraController = new CameraController();
            ProcessState.UpdateState("CameraConnected", true);

            _visionController = new VisionController();
            _MQTTManager = new MQTTManager();
            _busManager = new VPBusManager();
        }

        public async Task RunAsync(CancellationToken token)
        {
            Console.WriteLine("Run 호출");
            _visionNgService = new VisionNgService();
            

            // 상태 초기화
            ProcessState.UpdateState("CurrentStage", "waiting");    

            try
            {
                token.ThrowIfCancellationRequested();
                // 초기화 대기
                _arduinoController.ResetPosition();

                //타워램프 RED
                _arduinoController.LampOn("GREEN", onOff: false);
                _arduinoController.LampOn("RED", onOff: true);

                // MQTT 연결 상태 확인
                if (_MQTTManager.IsConnected)
                {
                    ProcessState.UpdateState("MQTTConnected", true);
                    mytoken = true;
                }
                else
                {
                    throw new InvalidOperationException("MQTT 연결 실패");
                }

                while (mytoken)
                {
                    try
                    {
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
                            Global.s_MQTTDTO.StageVal = "100";
                            try
                            {
                                await _MQTTManager.PublishMessageAsync(Global.s_MQTTDTO);
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
                            /*
                             * 비전검사 시작 후
                             * 1. 카메라 캡쳐
                             * 2. 비전처리
                             * 3. MQTT전송 : MQTTDTO
                             * 4. RestAPI 전송 : VisionNgReqDTO
                             * 5. VisionHistory에 인덱스 추가
                             */
                            //카메라 캡쳐
                            Mat img = await _cameraController.CaptureAsync();
                            //비전처리
                            VisionResultDTO visionResultDTO = new VisionResultDTO();
                            var imgAndLabel = await Task.Run(() => _visionController.ProcessImage(img, visionResultDTO),token); // 비동기로 처리
                            //비전 처리된 이미지 MQTTDTO에 할당
                            Global.s_MQTTDTO.NGImg = imgAndLabel.Img;
                        
                            var inspectionResult = ProcessState.GetState("InspectionResult");
                            Console.WriteLine($"판독 결과: {inspectionResult}");
                            await Task.Delay(2000, token); // 이미지 처리 대기

                            //MQTT에 CurrentStage와 MQTTDTO 전송
                            Global.s_MQTTDTO.StageVal = "010";
                            try
                            {
                                await _MQTTManager.PublishMessageAsync(Global.s_MQTTDTO);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"MQTT 메시지 발행 중 오류 발생: {ex.Message}");
                            }

                            //비전 히스토리 객체에 Label값과 검사 시간 넣기
                            _visionHistoryDTO = new VisionHistoryDTO
                            {
                                Label = VisionNgReqDTO.MapLabelToNgType(imgAndLabel.Labels),
                                EmployeeName = Global.s_LoginDTO?.Name ?? "Unknown"
                            };
                            //static List<VisionCumVO> 객체에 add
                            Global.s_VisionHistoryList.Add(_visionHistoryDTO);

                            //비전 판독 결과가 false인 경우 RestAPI 전송 : VisionNgReqDTO
                            if ((bool)inspectionResult == false)
                            {
                                VisionNgReqDTO dto = new VisionNgReqDTO()
                                {
                                    LotId = MenuInfoDTO.LotId,
                                    LineId = MenuInfoDTO.LineId,
                                    DateTime = DateTime.Now,
                                    Img = imgAndLabel.Img,
                                    NgLabel = VisionNgReqDTO.MapLabelToNgType(imgAndLabel.Labels)
                                };
                                dto.ToString();
                                await _visionNgService.InsertVisionNg(dto);


                            }
                            // img 초기화
                            Global.s_MQTTDTO.NGImg = null;
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

                            // MQTT에 CurrentStage 전송
                            Global.s_MQTTDTO.StageVal = "001";
                            try
                            {
                                await _MQTTManager.PublishMessageAsync(Global.s_MQTTDTO);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"MQTT 메시지 발행 중 오류 발생: {ex.Message}");
                            }

                            /*
                             *VisionCumVO 객체 생성 후
                             *1.Tcp 소켓서버에 전송
                             */
                        

                            _visionCumVO = new VisionCumVO()
                            {
                                LineId = MenuInfoDTO.LineId,
                                Time = DateTime.Now,
                                LotId = MenuInfoDTO.LotId,
                                Shift = Global.s_LoginDTO.Shift,
                                EmployeeNumber = Global.s_LoginDTO.EmployeeNumber,
                                Total = Global.s_VisionHistoryList.Count
                            };
                        
                            //소켓 서버 전송
                            try
                            {
                                _busManager.SendData(_visionCumVO);
                            }
                            catch (Exception ex) 
                            {
                                Console.WriteLine($"소켓서버 데이터 전송 실패: {ex}");
                            }

                            /*
                             *
                             */

                            if (!inspectionResult) // 검사 결과가 Bad인 경우
                            {
                                _arduinoController.SendConveyorSpeed(0);
                                await Task.Delay(2000, token);

                                // FlashLamp 실행 (노란색 램프 켜기)
                               _arduinoController.FlashLamp("YELLOW", true);

                                // 불량품 처리 로직
                                await Task.Run(() => _arduinoController.GrabObj());
                                await Task.Delay(2000,token);

                                await Task.Run(() => _arduinoController.PullObj());
                                await Task.Delay(2000, token);

                                await Task.Run(() => _arduinoController.MovToBad());
                                await Task.Delay(2000, token);

                                await Task.Run(() => _arduinoController.DownObj());
                                await Task.Delay(2000, token);

                                // 초기화 작업
                                _arduinoController.ResetPosition();
                                await _arduinoController.FlashLamp("YELLOW", false);

                                // 상태 전환: Idle
                                ProcessState.UpdateState("CurrentStage", "waiting");
                                _arduinoController.LampOn("RED", onOff: true);
                                Console.WriteLine("불량품 처리 완료, 대기 상태로 전환");
                            }
                        }
                    }
                    catch(Exception ex) 
                    {
                        Console.WriteLine($"캔슬토큰!! : {ex}");
                        break; // 🚀 while 루프 즉시 종료
                    }
                    
                    // ✅ 취소 가능 대기 추가
                    await Task.Delay(100, token);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");

            }
            finally
            {
                // 자원 정리 및 상태 초기화
                _arduinoController.SendConveyorSpeed(0);
                _arduinoController.ResetPosition();
                ProcessState.UpdateState("CurrentStage", "Idle");
                _arduinoController.LampOn("RED", onOff: false);
                _arduinoController.LampOn("GREEN", onOff:true);
                Console.WriteLine($"현재 stage: {ProcessState.GetState("CurrentStage")}");
            }
        }

        public async void Stop()
        {
            try
            {
                Console.WriteLine("작업 중단 요청");
                await _arduinoController.CloseConnectionAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"작업 중단 중 오류 발생: {ex.Message}");
            }
        }
    }
}
