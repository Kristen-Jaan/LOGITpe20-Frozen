using System;
using System.Collections.Generic;
using System.IO;

namespace Frozen
{
    class Program
    {
        class Frozen
        {
            string name;
            string item;

            public Frozen(string _name, string _item)
            {
                name = _name;
                item = _item;
            }

            public string Name {get { return name; } }
            public string Item {get { return item; } }
        }
        class FrozenList
        {
            List<Frozen> characters;

            public FrozenList()
            {
                characters = new List<Frozen>();
                
            }
            public void AddCharactersToList(string name, string item)
            {
                Frozen newFrozen = new Frozen(name, item);
                characters.Add(newFrozen);
            }

            public void PrintAllFrozens()
            {
                foreach(Frozen character in characters)
                {
                    Console.WriteLine($"{character.Name} wants {character.Item} for christmas.");
                }
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Help Me!");
            string filePath = @"C:\Users\opilane\Samples";
            string fileName = @"frozenl.txt";
            string fullFilePath = Path.Combine(filePath, fileName);

            string[] linesFromFile = File.ReadAllLines(fullFilePath);

            FrozenList characters = new FrozenList();
            foreach(string line in linesFromFile)
            {
                string[] tempArray = line.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string characterName = tempArray[0];
                string characterItem = tempArray[1];
                characters.AddCharactersToList(characterName, characterItem);

            }
            characters.PrintAllFrozens();
        }
    }
}
