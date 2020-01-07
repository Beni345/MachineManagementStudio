using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MMSLib.MQTT
{
    public class MQTTData : IMQTTData
    {
        public MqttClient IotClient { get;}

        public List<MQTTSubscribeInfo> MttSubscribeInfos { get; } = new List<MQTTSubscribeInfo>();

        public MQTTData(string brokerIP,int brokerPort )
        {

            //string iotendpoint = "104.45.10.62";
            //int BrokerPort = 1883;
            string ClientId = Guid.NewGuid().ToString();


            IotClient = new MqttClient(brokerIP);


            MttSubscribeInfos.Add(new MQTTSubscribeInfo("+/+/UcMachineSelector_001", MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE));
            MttSubscribeInfos.Add(new MQTTSubscribeInfo("+/+/UcMachineSelector_002", MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE));

            IotClient.Connect(ClientId);

            //SubscribeToTopics();

        }

        public void SubscribeToTopics()
        {
            ushort msgId = IotClient.Subscribe(MttSubscribeInfos.Select(t => t.TopicName).ToArray(), MttSubscribeInfos.Select(q => q.QosLevel).ToArray());
        }

    }
}
