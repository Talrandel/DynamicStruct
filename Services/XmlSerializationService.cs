using System.IO;
using LabaApp.Model;
using LabaApp.Model.Dto;
using System.Xml.Serialization;

namespace LabaApp.Services
{
    /// <inheritdoc/>
    class XmlSerializationService : ISerializationService<Node>
    {
        /// <inheritdoc/>
        private XmlSerializer _xmlSerializer;

        public XmlSerializationService()
        {
            _xmlSerializer = new XmlSerializer(typeof(NodeDto));
        }

        /// <inheritdoc/>
        public Node Deserialize(Stream stream)
        {
            var nodeDto = new NodeDto();
            nodeDto = (NodeDto)_xmlSerializer.Deserialize(stream);
            return nodeDto.Deserialize();
        }

        /// <inheritdoc/>
        public void Serialize(Node node, Stream stream)
        {
            var nodeDto = new NodeDto();
            nodeDto.Serialize(node);
            _xmlSerializer.Serialize(stream, nodeDto);
        }
    }
}