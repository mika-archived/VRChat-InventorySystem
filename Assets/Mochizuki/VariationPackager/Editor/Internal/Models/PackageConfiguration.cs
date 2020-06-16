using System.Collections.Generic;

using JetBrains.Annotations;

using Newtonsoft.Json;

namespace Mochizuki.VariationPackager.Internal.Models
{
    public class PackageConfiguration
    {
        [JsonProperty("name")]
        [CanBeNull]
        public string Name { get; set; }

        [JsonProperty("basedir")]
        [CanBeNull]
        public string BaseDir { get; set; }

        [JsonProperty("includes")]
        [CanBeNull]
        public List<string> Includes { get; set; }

        [JsonProperty("excludes")]
        [CanBeNull]
        public List<string> Excludes { get; set; }
    }
}