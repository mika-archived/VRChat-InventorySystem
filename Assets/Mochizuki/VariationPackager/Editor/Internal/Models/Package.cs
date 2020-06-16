using Newtonsoft.Json;

namespace Mochizuki.VariationPackager.Internal.Models
{
    internal class Package
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("moe.mochizuki.unity.packaging")]
        public PackageDescribe Describe { get; set; }
    }
}