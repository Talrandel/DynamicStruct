using Lab2_Lists.Infrastructure;
using System.Collections.Generic;

namespace Lab2_Lists.Model
{
    public class DynamicStruct : ObservableObject
    {
        private LinkedList<LevelOneNode> _items;

        public DynamicStruct()
        {
            Items = new LinkedList<LevelOneNode>();
        }

        public LinkedList<LevelOneNode> Items
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