using LabaApp.Model;

namespace LabaApp.Services
{
    /// <inheritdoc />
    public class DesignDataService : IDataService
    {
        /// <inheritdoc />
        public Node GetData(string fileName)
        {
            var t1 = new ObservableLinkedList<Node>();
            t1.AddLast(new Node()
            {
                Value = "ТРАНСАЭРО"
            });
            t1.AddLast(new Node()
            {
                Value = "АЭРОЛИФТ"
            });
            t1.AddLast(new Node()
            {
                Value = "ИСТЛАЙН"
            });
            var x1 = new Node
            {
                Value = "DME",
                SubNodes = t1
            };


            var t2 = new ObservableLinkedList<Node>();
            t2.AddLast(new Node()
            {
                Value = "САМАРА"
            });
            var x2 = new Node
            {
                Value = "KUF",
                SubNodes = t2
            };
            var t3 = new ObservableLinkedList<Node>();
            t3.AddLast(new Node()
            {
                Value = "КАРАТ"
            });
            var x3 = new Node
            {
                Value = "VKO",
                SubNodes = t3
            };

            var nodes = new ObservableLinkedList<Node>();
            nodes.AddLast(x1);
            nodes.AddLast(x2);
            nodes.AddLast(x3);

            return new Node
            {
                SubNodes = nodes
            };
        }
    }
}