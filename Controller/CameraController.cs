using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VP_QM_winform.Service;

namespace VP_QM_winform.Controller
{
    public class CameraController : IDisposable
    {
        private CancellationTokenSource captureCancellationTokenSource;
        private VideoCapture videoCapture;
        private string saveDirectory;
        private bool _isConnected; // 연결 상태 플래그
        public bool IsConnected => _isConnected; // 연결 상태를 확인하는 속성
        // 생성자: 카메라 연결 포함 여부에 따라 변경 가능
        public CameraController()
        {
            Connect();
        }

        // 카메라 연결 메서드
        public void Connect(int cameraIndex = 1)
        {
            if (videoCapture != null && videoCapture.IsOpened())
            {
                Console.WriteLine("카메라가 이미 연결되어 있습니다.");
                _isConnected = true;
                return;
            }

            videoCapture = new VideoCapture(cameraIndex);
            if (videoCapture.IsOpened())
            {
                Console.WriteLine("카메라 연결 성공");
                _isConnected = true; // 연결 상태 업데이트
            }
            else
            {
                _isConnected = false; // 연결 실패 상태
                throw new InvalidOperationException("카메라 연결에 실패했습니다.");
            }
        }

        // 이미지 캡처 메서드
        public async Task<Mat> CaptureAsync()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("카메라가 연결되지 않았습니다.");
            }


            Mat frame = new Mat();
            return await Task.Run(() =>
            {
                for (int i = 0; i < 5; i++) // 버퍼 비우기
                {
                    videoCapture.Grab();
                    videoCapture.Read(frame);
                }

                if (frame.Empty())
                {
                    throw new InvalidOperationException("이미지를 캡처할 수 없습니다.");
                }

                Console.WriteLine("이미지 캡처 성공");
                return frame;
            });
        }

        // 자원 해제 메서드
        public void Dispose()
        {

            if (videoCapture != null && videoCapture.IsOpened())
            {
                videoCapture.Release();
                Console.WriteLine("카메라 연결 해제");
            }
            _isConnected = false; // 연결 상태 초기화
        }

    }
}
