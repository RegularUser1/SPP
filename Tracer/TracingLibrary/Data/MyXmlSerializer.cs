using System.Xml.Serialization;

namespace TracingLibrary.Data
{
    public class MyXmlSerializer : ISerializer
    {
        public string Serialize(object obj)
        {
            var serializer = new XmlSerializer(obj.GetType());

            using var writer = new StringWriter();
            serializer.Serialize(writer, obj);

            return writer.ToString();
        }
    }
}
