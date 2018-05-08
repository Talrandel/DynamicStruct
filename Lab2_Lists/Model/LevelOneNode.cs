using System.Collections.Generic;

namespace Lab2_Lists.Model
{
    public class LevelOneNode : NodeBase
    {
        private LinkedList<LevelTwoNode> _items;

        public LevelOneNode()
            : this(NewName)
        {

        }

        public LevelOneNode(string name) 
            : base(name)
        {
            Items = new LinkedList<LevelTwoNode>();
        }

        public LinkedList<LevelTwoNode> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
    }
}