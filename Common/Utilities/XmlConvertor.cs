using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.Utilities
{
    public class XmlConvertor<Class> where Class : class
    {
        public string ToXML()
        {
            using (var stringWriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stringWriter, this);
                return stringWriter.ToString();
            }
        }

        public static Class LoadFromXMLString(string xmlText)
        {
            using (var stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(Class));
                return serializer.Deserialize(stringReader) as Class;
            }
        }
    }
}
