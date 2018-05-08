using Lab2_Lists.Model;

namespace Lab2_Lists.Services
{
    public interface IDynamicStructService
    {
        DynamicStruct GetDynamicStruct();

        void AddLevelOneNode(DynamicStruct dynamicStruct, LevelOneNode parentNode);

        void AddLevelTwoNode(DynamicStruct dynamicStruct, NodeBase parentNode);

        void DeleteLevelOneNode(DynamicStruct dynamicStruct, LevelOneNode node);

        void DeleteLevelTwoNode(DynamicStruct dynamicStruct, LevelTwoNode node);

        void UpdateLevelOneNode(DynamicStruct dynamicStruct, LevelOneNode node);

        void UpdateLevelTwoNode(DynamicStruct dynamicStruct, LevelTwoNode node);
    }
}