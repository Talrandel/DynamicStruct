using System;
using System.Collections.Generic;
using Lab2_Lists.Model;

namespace Lab2_Lists.Services
{
    public class DynamicStructService : IDynamicStructService
    {
        public DynamicStruct GetDynamicStruct()
        {
            return new DynamicStruct();
        }

        public void AddLevelOneNode(DynamicStruct dynamicStruct, LevelOneNode parentNode)
        {
            var newLevelOneNode = new LevelOneNode();
            if (parentNode == null)
            {
                dynamicStruct.Items.AddFirst(newLevelOneNode);
                return;
            }
            var linkedListParentNode = dynamicStruct.Items.Find(parentNode);
            dynamicStruct.Items.AddAfter(linkedListParentNode, newLevelOneNode);
        }

        public void AddLevelTwoNode(DynamicStruct dynamicStruct, NodeBase parentNode)
        {
            var newLevelTwoNode = new LevelTwoNode();
            if (parentNode == null)
                throw new ArgumentNullException(nameof(parentNode));

            var parentLevelOne = parentNode as LevelOneNode;
            if (parentLevelOne != null)
            {
                parentLevelOne.Items.AddFirst(newLevelTwoNode);
                return;
            }
            var parentLevelTwo = parentNode as LevelTwoNode;
            if (parentLevelTwo != null)
            {
                LinkedListNode<LevelTwoNode> linkedListParentNode;
                foreach (var item in dynamicStruct.Items)
                {
                    if ((linkedListParentNode = item.Items.Find(parentLevelTwo)) != null)
                    {
                        item.Items.AddAfter(linkedListParentNode, newLevelTwoNode);
                        return;
                    }
                }
            }
        }

        public void DeleteLevelOneNode(DynamicStruct dynamicStruct, LevelOneNode node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            dynamicStruct.Items.Remove(node);
        }

        public void DeleteLevelTwoNode(DynamicStruct dynamicStruct, LevelTwoNode node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            // TODO: может плюнуть на эту красивую обертку и сделать для каждого элемента два индекса, показывающие его
            // положение? Выбирая элемент, будет известна его позиция. И не нужно будет городить поиск по связным спискам
            foreach (var item in dynamicStruct.Items)
            {
                if (item.Items.Contains(node))
                {
                    item.Items.Remove(node);
                    return;
                }
            }
        }

        public void UpdateLevelOneNode(DynamicStruct dynamicStruct, LevelOneNode node)
        {
            throw new NotImplementedException();
        }

        public void UpdateLevelTwoNode(DynamicStruct dynamicStruct, LevelTwoNode node)
        {
            throw new NotImplementedException();
        }
    }
}