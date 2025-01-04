using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_QM_winform.Service
{
    public static class ProcessState
    {
        // ConcurrentDictionary를 사용하여 멀티 쓰레드의 상태를 중앙에서 관리
        public static ConcurrentDictionary<string,object> State = new ConcurrentDictionary<string,object>();

        //상태 초기화 (애플리케이션 시작 시 호출)
        public static void Initialize()
        {
            State["ArduinoConnected"] = false;        // 아두이노 연결 상태
            State["CameraConnected"] = false;         // 카메라 연결 상태
            State["VisionModelLoaded"] = false;       // ONNX 모델 로드 상태
            State["MQTTConnected"] = false;           // MQTT 연결 상태
            State["CurrentStage"] = "Idle";           // 현재 작업 단계 (Idle, Processing 등)
            State["InspectionResult"] = null;         // 비전 처리 결과 (성공/실패)
            State["LastMQTTMessage"] = null;          // MQTT로 마지막으로 보낸 메시지

        }

        // 상태 업데이트 메서드
        public static void UpdateState(string key, object value)
        {
            if (State.ContainsKey(key))
            {
                State[key] = value;
            }
            else
            {
                throw new ArgumentException($"상태 키 '{key}'가 존재하지 않습니다.");
            }
        }

        // 상태 읽기 메서드
        public static object GetState(string key)
        {
            if (State.ContainsKey(key))
            {
                return State[key];
            }
            throw new ArgumentException($"상태 키 '{key}'가 존재하지 않습니다.");
        }

        // 상태를 로그로 출력 (디버깅 및 모니터링 용도)
        public static void LogState()
        {
            Console.WriteLine("\n[Process State]");
            foreach (var kvp in State)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine();
        }
    }
}
