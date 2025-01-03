using MQTTnet.Client;
using MQTTnet.Protocol;
using MQTTnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_QM_winform.ComManager
{
    public class MQTTManager
    {
        private IMqttClient _mqttClient;

        public bool IsConnected => _mqttClient?.IsConnected ?? false;

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

        public async Task PublishMessageAsync(string topic, string message)
        {
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

    }
}
