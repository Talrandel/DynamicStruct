using LabaApp.Model;
using System.IO;

namespace LabaApp.Services
{
    public interface ISerializationService
    {
        void Serialize(Node node, Stream stream);

        Node Deserialize(Stream stream);
    }
}