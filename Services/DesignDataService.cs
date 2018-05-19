using LabaApp.Model;

namespace LabaApp.Services
{
    public class DesignDataService : IDataService
    {
        public Node GetData(string fileName)
        {
            var t = new ObservableLinkedList<Node>();

            t.AddLast(new Node()
            {
                Value = "ТРАНСАЭРО"
            });
            t.AddLast(new Node()
            {
                Value = "АЭРОФЛОТ"
            });

            var x1 = new Node
            {
                Value = "VKO",
                SubNodes = t
            };

            var x2 = new Node
            {
                Value = "KUF",
                SubNodes = new ObservableLinkedList<Node>()
            };

            var p = new ObservableLinkedList<Node>();
            p.AddLast(x1);
            p.AddLast(x2);

            return new Node
            {
                SubNodes = p
            };
        }
    }
}
