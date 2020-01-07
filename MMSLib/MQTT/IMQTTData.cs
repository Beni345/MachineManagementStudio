using System.Collections.Generic;
using uPLibrary.Networking.M2Mqtt;

namespace MMSLib.MQTT
{
    public interface IMQTTData
    {
        MqttClient IotClient { get; }
        List<MQTTSubscribeInfo> MttSubscribeInfos { get; }
        void SubscribeToTopics();
    }
}