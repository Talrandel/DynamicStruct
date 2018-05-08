using System.IO;
using Lab2_Lists.Model;

namespace Lab2_Lists.Services
{
    public interface IDynamicStructSerializerService
    {
        void Serialize(DynamicStruct dynamicStruct, Stream stream);

        DynamicStruct Deserialize(Stream stream);
    }
}