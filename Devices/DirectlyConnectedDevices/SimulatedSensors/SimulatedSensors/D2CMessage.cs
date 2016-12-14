using System.Runtime.Serialization;

namespace ConnectTheDotsHelper
{
    /// <summary>
    /// Data contract defining Connect The Dots data telemetry format
    /// </summary>
    [DataContract]
    public class D2CMessage
    {
        [DataMember]
        public string guid;

        [DataMember]
        public string gatewayid;

        [DataMember]
        public string deviceid;

        [DataMember]
        public string objecttype;
        
        [DataMember]
        public string timecreated;

        [DataMember]
        public double value;
    }
}