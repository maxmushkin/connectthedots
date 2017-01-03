using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SimulatedSensors.Contracts
{
    public class Asset
    {
        [JsonIgnore]
        public string GatewayName;

        [JsonIgnore]
        public bool Variation;

        [JsonProperty("DeviceName")]
        public string DeviceId;

        [JsonProperty("ObjectType_Instance")]
        public string ObjectTypeInstance;

        [JsonProperty("PresentValue")]
        public double Value;
    }
}
