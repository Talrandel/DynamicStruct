using Lab2_Lists.Infrastructure;

namespace Lab2_Lists.Model
{
    public class NodeBase : ObservableObject, INamedItem
    {
        private static int _newId = 1;
        public const string NewName = "Новый объект";

        private string _name;
        private int _id;

        public NodeBase()
            : this(_newId++, NewName)
        {
            
        }

        public NodeBase(string name)
            : this(_newId++, name)
        {

        }

        public NodeBase(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }
}