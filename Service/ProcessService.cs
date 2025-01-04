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

            await _arduinoController.ConnectToArduinoUnoAsync();
            _arduinoController.StartSerialReadThread();

            // 아두이노 포지션 초기화
            _arduinoController.ResetPosition();

            await Task.Delay(2000); // 초기화 대기
            Console.WriteLine("시작");

            bool isGood = false; // 기본값은 false
            MQTTDTO dto = new MQTTDTO
            {
                LineId = "Line001",
                LotId = "Lot123",
                Shift = "Day",
                EmployeeNumber = "E12345"
            };

            try
            {
                while (true)
                {
                    // 작업이 취소되었는지 확인
                    token.ThrowIfCancellationRequested();

                    if (_arduinoController.serialReceiveData.Contains("PS_3=ON"))
                    {
                        _arduinoController.serialReceiveData = "";
                        _arduinoController.SendConveyorSpeed(200);
                        Console.WriteLine("물건 투입");
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
                    else if (_arduinoController.serialReceiveData.Contains("PS_2=ON"))
                    {
                        _arduinoController.serialReceiveData = "";
                        await Task.Delay(1000, token); // 작업 취소 가능 대기
                        _arduinoController.SendConveyorSpeed(0);
                        await Task.Delay(2000, token);

                        Console.WriteLine("비전 검사 시작");

                        Mat img = await _cameraController.CaptureAsync(); // 비동기로 캡처
                        //ProcessImage에서 비전처리된 img를 dto의 NGImg 프로퍼티에 set
                        ImageProcessingResult result = await Task.Run(() => _visionController.ProcessImage(img,dto), token); // 비동기로 처리

                        isGood = result == ImageProcessingResult.Success;
                        Console.WriteLine($"판독 결과: {isGood}");
                        await Task.Delay(2000, token); // 이미지 처리 대기

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
                    else if (_arduinoController.serialReceiveData.Contains("PS_1=ON") && !isGood)
                    {
                        dto.StageVal = "001";
                        try
                        {
                            await _MQTTManager.PublishMessageAsync(dto);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"MQTT 메시지 발행 중 오류 발생: {ex.Message}");
                        }

                        _arduinoController.serialReceiveData = "";
                        _arduinoController.SendConveyorSpeed(0);
                        await Task.Delay(2000, token);

                        await Task.Run(() => _arduinoController.GrabObj(), token);
                        await Task.Delay(2000, token);

                        await Task.Run(() => _arduinoController.PullObj(), token);
                        await Task.Delay(2000, token);

                        await Task.Run(() => _arduinoController.MovToBad(), token);
                        await Task.Delay(2000, token);

                        await Task.Run(() => _arduinoController.DownObj(), token);
                        await Task.Delay(2000, token);

                        _arduinoController.ResetPosition();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
            finally
            {
                _arduinoController.ResetPosition();
                _arduinoController.CloseConnection();
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
