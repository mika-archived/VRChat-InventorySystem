using JetBrains.Annotations;

using Newtonsoft.Json;

namespace Mochizuki.VariationPackager.Internal.Models
{
    public class PackageVariation
    {
        public string Name { get; set; }

        [JsonProperty("archive")]
        [CanBeNull]
        public PackageConfiguration Archive { get; set; }

        [JsonProperty("unitypackage")]
        public PackageConfiguration UnityPackage { get; set; }
    }
}