using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VP_QM_winform.Controller
{
    public class ArduinoController
    {
        private SerialPort serialPort;
        public string serialReceiveData { set; get; }

        public ArduinoController()
        {
        }

        // 아두이노 연결 설정
        public async Task<bool> ConnectToArduinoUnoAsync()
        {
            var ports = GetSerialPortDescriptions();
            foreach (var port in ports)
            {
                try
                {
                    Console.WriteLine($"포트: {port.PortName}, 설명: {port.Description}");

                    if (port.Description.Contains("Arduino Uno"))
                    {
                        Console.WriteLine("아두이노 초기화 대기 중...");
                        await Task.Delay(2000); // 비동기로 대기

                        serialPort = new SerialPort(port.PortName, 9600);
                        serialPort.Open();
                        Console.WriteLine($"Arduino Uno가 포트 {port.PortName}에 연결되었습니다.");
                        return true; // 연결 성공
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"포트 {port.PortName} 스캔 중 오류: {ex.Message}");
                }
            }

            Console.WriteLine("Arduino Uno를 찾을 수 없습니다.");
            return false; // Arduino Uno를 찾지 못함
        }

        // 아두이노 데이터 읽기 쓰레드
        public void StartSerialReadThread()
        {
            Thread receiveThread = new Thread(SerialReadThread);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        private void SerialReadThread()
        {
            while (true)
            {
                try
                {
                    if (serialPort != null && serialPort.IsOpen)
                    {
                        string readData = serialPort.ReadLine();
                        serialReceiveData = readData;
                        Console.WriteLine($"수신: {readData}");
                    }
                }
                catch
                {
                    // 읽기 오류 무시
                }
            }
        }

        public void SendConveyorSpeed(int speed)
        {
            if (speed >= 0 && speed <= 255)
            {
                serialPort.WriteLine($"CV_MOTOR={speed}");
            }
            else
            {
                Console.WriteLine("0~255 사이의 값을 입력하세요.");
            }
        }

        public void SendServo1Angle(int angle)
        {
            if (angle >= 60 && angle <= 130)
            {
                serialPort.WriteLine($"SERVO_1={angle}");
            }
            else
            {
                Console.WriteLine("60~130 사이의 값을 입력하세요.");
            }
        }

        public void SendServo2Angle(int angle)
        {
            if (angle >= 0 && angle <= 180)
            {
                serialPort.WriteLine($"SERVO_2={angle}");
            }
            else
            {
                Console.WriteLine("0~180 사이의 값을 입력하세요.");
            }
        }

        public void SendServo3Angle(int angle)
        {
            if (angle >= 30 && angle <= 120)
            {
                serialPort.WriteLine($"SERVO_3={angle}");
            }
            else
            {
                Console.WriteLine("30~120 사이의 값을 입력하세요.");
            }
        }

        public void SendCatchOnOff(bool onOff)
        {
            if (onOff)
            {
                serialPort.WriteLine("CATCH=ON");
            }
            else
            {
                serialPort.WriteLine("CATCH=OFF");
            }
        }

        public void ResetPosition()
        {
            SendServo1Angle(80);
            SendServo2Angle(180);
            SendServo3Angle(100);
            SendCatchOnOff(false);
            Console.WriteLine("초기 위치로 리셋");
        }

        public void GrabObj()
        {
            Console.WriteLine("물건 잡음");
            SendServo1Angle(130);
            SendServo2Angle(180);
            SendServo3Angle(95);
            Thread.Sleep(1000);
            SendCatchOnOff(true);
        }

        public void PullObj()
        {
            Console.WriteLine("물건 올림");
            SendServo1Angle(80);
            SendServo2Angle(180);
            SendServo3Angle(95);
        }

        public void DownObj()
        {
            Console.WriteLine("물건 내림");
            SendServo1Angle(130);
            SendServo2Angle(90);
            SendServo3Angle(95);
            Thread.Sleep(2000);
            SendCatchOnOff(false);

        }

        public void MovToBad()
        {
            Console.WriteLine("불량 박스로 물건 이동");
            SendServo1Angle(80);
            SendServo2Angle(90);
            SendServo3Angle(95);

        }

        private (string PortName, string Description)[] GetSerialPortDescriptions()
        {
            var portDescriptions = new List<(string PortName, string Description)>();
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'");

            foreach (var obj in searcher.Get())
            {
                string name = obj["Name"]?.ToString();
                string portName = name?.Split('(')[1].Trim(')');
                string description = obj["Description"]?.ToString() ?? "Unknown Device";

                portDescriptions.Add((portName, description));
            }

            return portDescriptions.ToArray();
        }

        public void CloseConnection()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
                Console.WriteLine("시리얼 포트 닫힘");
            }
        }

    }
}
