using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSLib.MQTT
{
    public class MQTTSubscribeInfo
    {
        public string TopicName { get; set; }
        public byte QosLevel { get; set; }


        public MQTTSubscribeInfo(string topicName, byte qosLevel)
        {
            TopicName = topicName;
            QosLevel = qosLevel;
        }
    }
}
