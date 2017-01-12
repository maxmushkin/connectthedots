using System.ComponentModel;
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

        [JsonProperty("ObjectType")]
        public string ObjectType;

        [JsonProperty("Instance", 
            DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore
            ),DefaultValue("")]
        public string Instance;

        [JsonProperty("PresentValue")]
        public double Value;
    }
}
