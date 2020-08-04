using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using Landorphan.BuildMap.Model.Support;
using Landorphan.BuildMap.Serialization.Attributes;
using Newtonsoft.Json;

namespace Landorphan.BuildMap.Model
{
    [Serializable]
    public class Project
    {
        [JsonProperty(Order = 0)]
        [TableDefaultDisplay]
        public int Group { get; set; }

        [JsonProperty(Order = 1)]
        [TableDefaultDisplay]
        [TextDefaultDisplay]
        public int Item { get; set; }
        
        [XmlArrayItem("Type")]
        [JsonProperty(Order = 2)]
        [TableDefaultDisplay]
        public StringList Types { get; set; } = new StringList();

        [JsonProperty(Order = 3)]
        [TableDefaultDisplay]
        public Language Language { get; set; }

        [JsonProperty(Order = 4)]
        [TableDefaultDisplay]
        public string Name { get; set; }

        [XmlArrayItem("Solution")]
        [JsonProperty(Order = 5)]
        [TableDefaultDisplay]
        public StringList Solutions { get; set; } = new StringList();

        [JsonProperty(Order = 6)]
        [TableDefaultDisplay]
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonProperty(Order = 7)]
        public string RelativePath { get; set; }

        [JsonProperty(Order = 8)]
        [TextDefaultDisplay]
        public string AbsolutePath { get; set; }

        [JsonProperty(Order = 9)]
        public string RealPath { get; set; }

        [XmlArrayItem("Id")]
        [JsonProperty(Order = 10)]
        [TableDefaultDisplay]
        public GuidList Dependencies { get; set; } = new GuidList();
    }
}