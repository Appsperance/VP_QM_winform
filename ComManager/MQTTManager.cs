using MQTTnet.Client;
using MQTTnet.Protocol;
using MQTTnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_QM_winform.DTO;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace VP_QM_winform.ComManager
{
    public class MQTTManager
    {
        private IMqttClient _mqttClient;

        public bool IsConnected => _mqttClient?.IsConnected ?? false;

        public MQTTManager(string brokerAddress, int port, string username, string password)
        {
            // 생성자에서 MQTT 클라이언트를 초기화하고 연결
            Task.Run(async () =>
            {
                try
                {
                    await ConnectAsync(brokerAddress, port, username, password);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"생성자에서 MQTT 연결 실패: {ex.Message}");
                }
            }).Wait(); // 비동기 호출을 동기화
        }

        public async Task ConnectAsync(string brokerAddress, int port, string username, string password)
        {
            try
            {
                var factory = new MqttFactory();
                _mqttClient = factory.CreateMqttClient();

                var options = new MqttClientOptionsBuilder()
                    .WithClientId(Guid.NewGuid().ToString())
                    .WithTcpServer(brokerAddress, port)
                    .WithCredentials(username, password)
                    .WithCleanSession()
                    .Build();

                await _mqttClient.ConnectAsync(options);
                Console.WriteLine("MQTT 브로커 연결 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MQTT 브로커 연결 실패: {ex.Message}");
                throw;
            }
        }

        public async Task PublishMessageAsync(MQTTDTO dto)
        {
            //await EnsureMqttConnectionAsync();

            string topic = "Vision.ng";
            string message = JsonConvert.SerializeObject(dto);

            if (_mqttClient == null || !_mqttClient.IsConnected)
            {
                throw new InvalidOperationException("MQTT client is not connected.");
            }
    
            try
            {
                var mqttMessage = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(Encoding.UTF8.GetBytes(message))
                    .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtMostOnce)
                    .WithRetainFlag(false)
                    .Build();

                await _mqttClient.PublishAsync(mqttMessage);
                Console.WriteLine($"Message sent to topic '{topic}': {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MQTT 메시지 발행 실패: {ex.Message}");
                throw;
            }
        }

        public async Task DisconnectAsync()
        {
            try
            {
                if (_mqttClient != null)
                {
                    await _mqttClient.DisconnectAsync();
                    Console.WriteLine("MQTT 브로커 연결 해제");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MQTT 브로커 연결 해제 실패: {ex.Message}");
                throw;
            }
        }
        /*
        private async Task EnsureMqttConnectionAsync()
        {
            string brokerAddress = "43.203.159.137";
            string username = "admin";
            string password = "vapor";
            int port = 1883;
            if (_mqttClient == null || !_mqttClient.IsConnected)
            {
                Console.WriteLine("MQTT 클라이언트 연결이 끊어졌습니다. 다시 연결을 시도합니다...");
                try
                {
                    var options = new MqttClientOptionsBuilder()
                    .WithClientId(Guid.NewGuid().ToString())
                    .WithTcpServer(brokerAddress, port)
                    .WithCredentials(username, password)
                    .WithCleanSession()
                    .Build();

                    await _mqttClient.ConnectAsync(options);
                    Console.WriteLine("MQTT 클라이언트가 다시 연결되었습니다.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"MQTT 재연결 실패: {ex.Message}");
                    throw;
                }
            }
        }*/

    }
}
