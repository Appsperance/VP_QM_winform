using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_QM_winform.Controller;

namespace VP_QM_winform.Service
{
    public class ProcessService
    {
        private readonly ArduinoController _arduinoController;
        private readonly CameraController _cameraController;
        private readonly VisionController _visionController;

        private bool isGood { get; set; }
        public ProcessService()
        {
            _arduinoController = new ArduinoController();
            _cameraController = new CameraController();
            _visionController = new VisionController();
        }

        public async Task RunAsync()
        {
            Console.WriteLine("Run 호출");

            await _arduinoController.ConnectToArduinoUnoAsync();
            _arduinoController.StartSerialReadThread();

            // 아두이노 포지션 초기화
            _arduinoController.ResetPosition();

            await Task.Delay(2000); // 초기화 대기
            Console.WriteLine("시작");

            try
            {
                while (true)
                {
                    if (_arduinoController.serialReceiveData.Contains("PS_3=ON"))
                    {
                        _arduinoController.serialReceiveData = "";
                        _arduinoController.SendConveyorSpeed(200);
                        Console.WriteLine("물건 투입");
                    }
                    else if (_arduinoController.serialReceiveData.Contains("PS_2=ON"))
                    {
                        _arduinoController.serialReceiveData = "";
                        await Task.Delay(1000); // 물체 대기
                        _arduinoController.SendConveyorSpeed(0);
                        await Task.Delay(2000);

                        Console.WriteLine("비전 검사 시작");

                        Mat img = await _cameraController.CaptureAsync(); // 비동기로 캡처
                        ImageProcessingResult result = await Task.Run(() => _visionController.ProcessImage(img)); // 비동기로 처리

                        bool isGood = result == ImageProcessingResult.Success;
                        Console.WriteLine($"판독 결과: {isGood}");
                        await Task.Delay(2000); // 이미지 처리 대기
                        //img 초기화
                        img.Dispose();
                        _arduinoController.SendConveyorSpeed(200);
                    }
                    else if (_arduinoController.serialReceiveData.Contains("PS_1=ON") && !isGood)
                    {
                        _arduinoController.serialReceiveData = "";
                        _arduinoController.SendConveyorSpeed(0);
                        await Task.Delay(2000);

                        await Task.Run(() => _arduinoController.GrabObj());
                        await Task.Delay(2000);

                        await Task.Run(() => _arduinoController.PullObj());
                        await Task.Delay(2000);

                        await Task.Run(() => _arduinoController.MovToBad());
                        await Task.Delay(2000);

                        await Task.Run(() => _arduinoController.DownObj());
                        await Task.Delay(2000);

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
    }
}
