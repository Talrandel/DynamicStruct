using System;
using System.Linq;
using System.Xml.Serialization;

namespace LabaApp.Model.Dto
{
    [Serializable]
    public class NodeDto
    {
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }

        [XmlArray(ElementName = "subnodes")]
        [XmlArrayItem(ElementName = "node", Type = typeof(NodeDto))]
        public NodeDto[] SubNodes { get; set; }

        public NodeDto(Node node)
        {
            Serialize(node);
        }

        public NodeDto()
        {

        }

        public void Serialize(Node node)
        {
            Value = node.Value;
            SubNodes = node.SubNodes.Select(subNode => new NodeDto(subNode)).ToArray();
        }

        public Node Deserialize()
        {
            var result = new Node()
            {
                Value = Value,
                SubNodes = new ObservableLinkedList<Node>()
            };
            foreach (var item in SubNodes)
                result.SubNodes.AddLast(item.Deserialize());
            return result;
        }
    }
}