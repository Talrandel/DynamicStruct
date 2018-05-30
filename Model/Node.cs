using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace LabaApp.Model
{
    /// <summary>
    /// Узел/элемент списка.
    /// </summary>
    public class Node : ObservableObject
    {
        private string _value;
        private Node _parent;
        private ObservableLinkedList<Node> _subNodes;
        private bool _highlight;

        /// <summary>
        /// Конструктор <see cref="Node"/>.
        /// </summary>
        public Node()
        {
            SubNodes = new ObservableLinkedList<Node>();

            AddNodeCommand = new RelayCommand(AddNode);
            SearchCommand = new RelayCommand<string>(Search);
            ClearCommand = new RelayCommand(Clear);
            DeleteNodeCommand = new RelayCommand(DeleteNode);
        }

        /// <summary>
        /// Подсвечен ли элемент (при поиске).
        /// </summary>
        public bool Highlight
        {
            get { return _highlight; }
            set { Set(ref _highlight, value); }
        }

        /// <summary>
        /// Коллекция дочерних элементов.
        /// </summary>
        public ObservableLinkedList<Node> SubNodes
        {
            get { return _subNodes; }
            set { Set(ref _subNodes, value); }
        }

        /// <summary>
        /// Текстовое значение элемента (имя).
        /// </summary>
        public string Value
        {
            get { return _value; }
            set { Set(ref _value, value); }
        }

        /// <summary>
        /// Родительский элемент.
        /// </summary>
        public Node Parent
        {
            get { return _parent; }
            set { Set(ref _parent, value); }
        }

        /// <summary>
        /// Добавить дочерний элемент.
        /// </summary>
        private void AddNode()
        {
            SubNodes.AddLast(new Node() { Value = "Новый элемент", Parent = this });
        }

        /// <summary>
        /// Поиск элемента с заданным текстом (текущий элемент и его дочерние элементы).
        /// </summary>
        /// <param name="text">Текст для поиска.</param>
        private void Search(string text)
        {
            Highlight = Value?.Contains(text) ?? false;
            foreach (Node subnode in SubNodes)
                subnode.Search(text);
        }

        /// <summary>
        /// Сброс поиска.
        /// </summary>
        private void Clear()
        {
            Highlight = false;
            foreach (Node subnode in SubNodes)
                subnode.Clear();
        }

        /// <summary>
        /// Удалить данный элемент.
        /// </summary>
        private void DeleteNode()
        {
            Parent.SubNodes.Remove(this);
        }

        /// <summary>
        /// Команда поиска значения элемента.
        /// </summary>
        public ICommand SearchCommand { get; }

        /// <summary>
        /// Команда добавления элемента.
        /// </summary>
        public ICommand AddNodeCommand { get; }

        /// <summary>
        /// Команда сброса поиска.
        /// </summary>
        public ICommand ClearCommand { get; }

        /// <summary>
        /// Команда удаления элемента.
        /// </summary>
        public ICommand DeleteNodeCommand { get; }
    }
}