using System.IO;
using LabaApp.Model;
using LabaApp.Model.Dto;
using System.Xml.Serialization;
using System;
using System.Xml;

namespace LabaApp.Services
{
    /// <inheritdoc/>
    public class XmlSerializationService : ISerializationService<Node>
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
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            var nodeDto = new NodeDto();
            try
            {
                nodeDto = (NodeDto)_xmlSerializer.Deserialize(stream);
            }
            catch (InvalidOperationException e1)
            {
                return null;
            }
            catch (XmlException e2)
            {
                return null;
            }
            catch (FileNotFoundException e3)
            {
                return null;
            }
            return nodeDto.Deserialize();
        }

        /// <inheritdoc/>
        public void Serialize(Node node, Stream stream)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            var nodeDto = new NodeDto();
            try
            {
                nodeDto.Serialize(node);
                _xmlSerializer.Serialize(stream, nodeDto);
            }
            catch (XmlException e1)
            {

            }
        }
    }
}