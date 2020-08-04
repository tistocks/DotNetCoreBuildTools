using Landorphan.BuildMap.Model;
using Landorphan.BuildMap.Serialization.Converters;
using Landorphan.BuildMap.Serialization.Formatters.Interfaces;
using Newtonsoft.Json;

namespace Landorphan.BuildMap.Serialization.Formatters.Implementation
{
    public class JsonFormatter : IFormatter
    {
        public string Write(Map map)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            settings.Converters.Add(new VersionStringJsonConverter());
            return JsonConvert.SerializeObject(map, settings);
        }

        public bool SniffValidFormat(string text)
        {
            return text.StartsWith("{");
        }

        public Map Read(string text)
        {
            return JsonConvert.DeserializeObject<Map>(text);
        }
    }
}