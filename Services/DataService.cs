using LabaApp.Model;

namespace LabaApp.Services
{
    /// <inheritdoc />
    public class DataService : IDataService
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
            foreach (var node in x1.SubNodes)
            {
                node.Parent = x1;
            }


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
            foreach (var node in x2.SubNodes)
            {
                node.Parent = x2;
            }


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
            foreach (var node in x3.SubNodes)
            {
                node.Parent = x3;
            }

            var nodes = new ObservableLinkedList<Node>();
            nodes.AddLast(x1);
            nodes.AddLast(x2);
            nodes.AddLast(x3);

            var root = new Node
            {
                SubNodes = nodes
            };
            foreach (var node in nodes)
            {
                node.Parent = root;
            }

            return root;
        }
    }
}