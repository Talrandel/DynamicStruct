using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace LabaApp.Model
{
    public class Node : ObservableObject
    {
        private string _value;
        private Node _parent;
        private ObservableLinkedList<Node> _subNodes;
        private bool _highlight;

        public Node()
        {
            SubNodes = new ObservableLinkedList<Node>();

            AddNodeCommand = new RelayCommand(AddNode);
            SearchCommand = new RelayCommand<string>(Search);
            ClearCommand = new RelayCommand(Clear);
            DeleteNodeCommand = new RelayCommand(DeleteNode);
        }

        public bool Highlight
        {
            get { return _highlight; }
            set { Set(ref _highlight, value); }
        }

        public ObservableLinkedList<Node> SubNodes
        {
            get { return _subNodes; }
            set { Set(ref _subNodes, value); }
        }

        public string Value
        {
            get { return _value; }
            set { Set(ref _value, value); }
        }

        public Node Parent
        {
            get { return _parent; }
            set { Set(ref _parent, value); }
        }

        private void AddNode()
        {
            SubNodes.AddLast(new Node() { Value = "Новый элемент", Parent = this });
        }

        private void Search(string text)
        {
            Highlight = Value?.Contains(text) ?? false;
            foreach (Node subnode in SubNodes)
                subnode.Search(text);
        }

        private void Clear()
        {
            Highlight = false;
            foreach (Node subnode in SubNodes)
                subnode.Clear();
        }

        private void DeleteNode()
        {
            Parent.SubNodes.Remove(this);
        }

        public ICommand SearchCommand { get; }

        public ICommand AddNodeCommand { get; }

        public ICommand ClearCommand { get; }

        public ICommand DeleteNodeCommand { get; }
    }
}