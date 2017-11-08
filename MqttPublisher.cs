using System;
using System.Collections.Generic;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Net;

namespace apiScraper
{
    class MqttPublisher
    {
        private MqttClient client;

        public MqttPublisher()
        {
            // This should be updated by the actual hostname of the MQTT broker
            client = new MqttClient("localhost");
            string clientId = Guid.NewGuid().ToString();
            try
            {
                client.Connect(clientId);
                string[] topics = { "/weather", "/traffic" };
                byte[] toBytes = Encoding.ASCII.GetBytes("Mooi weer");
                client.Publish("/weather", toBytes);
                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Could not connect to MQTT Broker");
            }

        }

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Console.WriteLine("MQTT Received");
            Console.WriteLine("Topic: " + e.Topic);
            Console.WriteLine("Message: " + e.Message);
        }
    }
}
