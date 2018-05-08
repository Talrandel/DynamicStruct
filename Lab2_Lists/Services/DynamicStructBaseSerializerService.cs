using Lab2_Lists.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lab2_Lists.Services
{
    public class DynamicStructBaseSerializerService : IDynamicStructSerializerService
    {           
        public DynamicStruct Deserialize(Stream stream)
        {
            var lines = new List<string>();

            // Читаем содержимое файла в список
            using (var sr = new StreamReader(stream))
            {
                var tempString = string.Empty;
                while ((tempString = sr.ReadLine()) != null)
                {
                    lines.Add(tempString);
                }
            }

            if (lines.Count == 0)
                throw new Exception("Входной файл пуст!");

            var dynamicStruct = new DynamicStruct();
            // Проверка целостности данных и разбиение входных строк на две, пригодные для дальшейшего преобразования
            var tempStruct = new Dictionary<string, List<string>>();
            for (int i = 0; i < lines.Count; i++)
            {
                var splittedString = lines[i].Split(new[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (splittedString.Length != 2)
                    throw new Exception(string.Format("Неверное количество входных параметров в исходном файле! Строка {0}", i + 1));
                var levelOne = splittedString[1];
                var levelTwo = splittedString[0];
                // Если в словаре нет элемента первого уровня с заданным именем, то добавить его в словарь
                if (!tempStruct.ContainsKey(levelOne))
                    tempStruct.Add(levelOne, new List<string>());
                else
                {
                    // Иначе он есть, и у его списка элементов второго уровня отсутствует только что считанный, добавить его
                    if (!tempStruct[levelOne].Contains(levelTwo))
                        tempStruct[levelOne].Add(levelTwo);
                }
            }
            foreach (var firstLevel in tempStruct.Keys)
            {
                var newLevelOneNode = new LevelOneNode(firstLevel);

                foreach (var secondLevel in tempStruct[firstLevel])
                    newLevelOneNode.Items.AddLast(new LevelTwoNode(secondLevel));

                var addedLevelOneNode = dynamicStruct.Items.AddLast(newLevelOneNode);
            }

            return dynamicStruct;
        }

        public void Serialize(DynamicStruct dynamicStruct, Stream stream)
        {
            var lines = new List<string>();
            foreach (var levelOne in dynamicStruct.Items)
            {
                foreach (var levelTwo in levelOne.Items)
                {
                    lines.Add(levelTwo.Name + " " + levelOne.Name);
                }
            }

            using (var sw = new StreamWriter(stream))
            {
                foreach (var line in lines)
                    sw.WriteLine(line);
            }
        }
    }
}