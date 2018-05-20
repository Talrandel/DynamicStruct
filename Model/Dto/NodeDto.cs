using System;
using System.Linq;
using System.Xml.Serialization;

namespace LabaApp.Model.Dto
{
    /// <summary>
    /// Обёртка для сериализации типа <see cref="Node"/> в XML.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "node")]
    public class NodeDto
    {
        /// <summary>
        /// Имя элемента.
        /// </summary>
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Список дочерних элементов.
        /// </summary>
        [XmlArray(ElementName = "subnodes")]
        [XmlArrayItem(ElementName = "node", Type = typeof(NodeDto))]
        public NodeDto[] SubNodes { get; set; }

        /// <summary>
        /// Конструктор <see cref="NodeDto"/>.
        /// </summary>
        /// <param name="node"></param>
        public NodeDto(Node node)
        {
            Serialize(node);
        }

        /// <summary>
        /// Конструктор <see cref="NodeDto"/> по умолчанию.
        /// </summary>
        public NodeDto()
        {

        }

        /// <summary>
        /// Инициализация объекта сериализации на основе объекта модели.
        /// </summary>
        /// <param name="node"></param>
        public void Serialize(Node node)
        {
            Value = node.Value;
            SubNodes = node.SubNodes.Select(subNode => new NodeDto(subNode)).ToArray();
        }

        /// <summary>
        /// Получение объекта модели на основе объекта сериализации.
        /// </summary>
        /// <returns></returns>
        public Node Deserialize()
        {
            return DeserializeInner();
        }

        private Node DeserializeInner(Node parent = null)
        {
            var result = new Node()
            {
                Parent = parent,
                Value = Value,
                SubNodes = new ObservableLinkedList<Node>()
            };
            foreach (var item in SubNodes)
                result.SubNodes.AddLast(item.DeserializeInner(result));
            return result;
        }
    }
}