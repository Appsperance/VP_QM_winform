using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using VP_QM_winform.VO;

namespace VP_QM_winform.ComManager
{
    public class VPBusManager
    {
        //TCP소켓 클라이언트 
        private TcpClient client;
        private NetworkStream stream;
        //로컬호스트
        //private const string addr = "127.0.0.1";
        private const string addr = "13.125.114.64";

        public VPBusManager()
        {
            Connect();
        }
        
        public void Connect()
        {
            try
            {
                client = new TcpClient(addr, 51900);
                stream = client.GetStream();
                Console.WriteLine("[CLIENT] Connected to server.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to connect to server: {ex.Message}");
            }
        }

        // 서버와의 연결 종료 메서드
        public void Disconnect()
        {
            try
            {
                stream?.Close();
                client?.Close();
                Console.WriteLine("[CLIENT] Disconnected from server.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
            }
        }

        // 데이터 전송 메서드
        public void SendData(VisionCumVO visionCumVO)
        {
            try
            {
                // VisionCumVO 객체를 바이트 배열로 변환
                byte[] message = CreateMessage(visionCumVO);

                // 데이터 전송
                Console.WriteLine("[CLIENT] Sending data to server...");
                stream.Write(message, 0, message.Length);
                Console.WriteLine("[CLIENT] Data sent.");

                // 서버 응답 수신
                byte[] responseBuffer = new byte[1024];
                int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
                string response = Encoding.ASCII.GetString(responseBuffer, 0, bytesRead);
                Console.WriteLine($"[CLIENT] Server response: {response}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
            }
        }

        // 데이터 변환 메서드 (VisionCumVO -> 바이트 배열)
        private byte[] CreateMessage(VisionCumVO visionCumVO)
        {
            // 데이터 변환
            byte[] lineIdBytes = Encoding.ASCII.GetBytes(visionCumVO.LineId.PadRight(4, '\0')); // LineId (4바이트)
            byte[] timeBytes = BitConverter.GetBytes(new DateTimeOffset(visionCumVO.Time).ToUnixTimeMilliseconds());
            byte[] lotIdBytes = Encoding.ASCII.GetBytes(visionCumVO.LotId.PadRight(20, '\0')); // LotId (20바이트)
            byte[] shiftBytes = Encoding.ASCII.GetBytes(visionCumVO.Shift.PadRight(4, '\0')); // Shift (4바이트)
            byte[] employeeNumberBytes = BitConverter.GetBytes((long)visionCumVO.EmployeeNumber); // EmployeeNumber (4바이트)
            byte[] totalBytes = BitConverter.GetBytes(visionCumVO.Total); // Total (4바이트)

            // 페이로드 생성
            byte[] payload = new byte[50];
            Buffer.BlockCopy(lineIdBytes, 0, payload, 0, lineIdBytes.Length);
            Buffer.BlockCopy(timeBytes, 0, payload, 4, timeBytes.Length);
            Buffer.BlockCopy(lotIdBytes, 0, payload, 12, lotIdBytes.Length);
            Buffer.BlockCopy(shiftBytes, 0, payload, 32, shiftBytes.Length);
            Buffer.BlockCopy(employeeNumberBytes, 0, payload, 36, employeeNumberBytes.Length);
            Buffer.BlockCopy(totalBytes, 0, payload, 40, totalBytes.Length);

            // 헤더 생성
            byte frameType = 2; // JWT = 1, CUM = 2
            byte[] messageLength = BitConverter.GetBytes((ushort)payload.Length);
            byte messageVersion = 1; // 프로토콜 버전
            byte role = 2; // 예: 생산 = 1, 품질 = 2
            byte reserved = 0; // 스페어

            byte[] header = new byte[6];
            header[0] = frameType;
            Buffer.BlockCopy(messageLength, 0, header, 1, messageLength.Length); ;
            header[3] = messageVersion;
            header[4] = role;
            header[5] = reserved;

            // 전체 메시지 생성
            byte[] message = new byte[header.Length + payload.Length];
            Buffer.BlockCopy(header, 0, message, 0, header.Length);
            Buffer.BlockCopy(payload, 0, message, header.Length, payload.Length);

            return message;
        }

    }
}
