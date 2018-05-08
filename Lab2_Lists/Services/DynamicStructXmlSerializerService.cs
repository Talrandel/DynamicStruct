using System.IO;
using Lab2_Lists.Model;
using System.Xml.Serialization;

namespace Lab2_Lists.Services
{
    public class DynamicStructXmlSerializerService : IDynamicStructSerializerService
    {
        private XmlSerializer _serializer;

        public DynamicStructXmlSerializerService()
        {
            _serializer = new XmlSerializer(typeof(DynamicStruct));
        }
           
        public DynamicStruct Deserialize(Stream stream)
        {
            var dynamicStruct = (DynamicStruct)_serializer.Deserialize(stream);
            return dynamicStruct;
        }

        public void Serialize(DynamicStruct dynamicStruct, Stream stream)
        {
            _serializer.Serialize(stream, dynamicStruct);
        }
    }
}