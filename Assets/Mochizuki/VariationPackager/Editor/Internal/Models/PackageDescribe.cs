using System.Collections.Generic;

using JetBrains.Annotations;

using Newtonsoft.Json;

namespace Mochizuki.VariationPackager.Internal.Models
{
    internal class PackageDescribe
    {
        [JsonProperty("output")]
        public string Output { get; set; }

        [JsonProperty("variations")]
        public List<PackageVariation> Variations { get; set; }
    }
}