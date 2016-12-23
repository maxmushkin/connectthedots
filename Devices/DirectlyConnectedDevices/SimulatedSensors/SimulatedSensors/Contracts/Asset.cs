﻿using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SimulatedSensors.Contracts
{
    public class Asset
    {
        public string GatewayId;

        [JsonProperty("DeviceId")]
        public string DeviceId;

        [JsonProperty("ObjectType_Instance")]
        public string ObjectTypeInstance;

        [JsonProperty("Value")]
        public double Value;
    }
}
