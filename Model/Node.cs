using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace LabaApp.Model
{
    public class Node : ObservableObject
    {
        private string _value;
        private ObservableLinkedList<Node> _row;
        private bool _highlight;

        public Node()
        {
            SubNodes = new ObservableLinkedList<Node>();

            AddNodeCommand = new RelayCommand(() => SubNodes.AddLast(new Node()));
            SearchCommand = new RelayCommand<string>(Search);
            ClearCommand = new RelayCommand(Clear);
        }

        public bool Highlight
        {
            get { return _highlight; }
            set { Set(ref _highlight, value); }
        }

        public ObservableLinkedList<Node> SubNodes
        {
            get { return _row; }
            set { Set(ref _row, value); }
        }

        public string Value
        {
            get { return _value; }
            set { Set(ref _value, value); }
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

        public ICommand SearchCommand { get; }

        public ICommand AddNodeCommand { get; }

        public ICommand ClearCommand { get; }
    }
}