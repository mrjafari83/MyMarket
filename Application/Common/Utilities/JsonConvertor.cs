using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Application.Common.Utilities
{
    public class JsonConvertor<Class> where Class : class
    {
        public static string ToJson(Class source)
        {
            using (var stringWriter = new System.IO.StringWriter())
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(stringWriter, source);
                return stringWriter.ToString();
            }
        }

        public static Class LoadFromJsonString(string jsonText)
        {
            return JsonConvert.DeserializeObject<Class>(jsonText);
        }
    }
}
