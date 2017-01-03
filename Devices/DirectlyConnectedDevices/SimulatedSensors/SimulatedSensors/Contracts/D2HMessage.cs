using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SimulatedSensors.Contracts
{
    public class D2HMessage
    {
        public D2HMessage(Asset asset)
        {
            this.Asset = asset;
            this.GatewayName = asset.GatewayName;
            this.Timestamp = DateTime.UtcNow.ToString("o");
        }

        [JsonProperty("GatewayName")]
        public string GatewayName;

        [JsonProperty("Timestamp")]
        public string Timestamp;

        [JsonProperty("Asset")]
        public Asset Asset;
    }
}
