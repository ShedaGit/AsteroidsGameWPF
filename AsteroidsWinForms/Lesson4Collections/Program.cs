using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lesson4Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
            //а и в) для целых чисел с помощью Linq;
            var listA = new List<int>() { 1, 2, 3, 4, 4, 4, 5, 5, 6, 7, 7, 7, 7, 8, 9 };

            foreach (var group in listA.GroupBy(x => x))
            {
                Console.WriteLine($"Элемент {group.Key} встречается в количестве {group.Count()} штук");
            }

            Console.WriteLine();

            //Дан фрагмент программы:
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four", 4 },
                {"two", 2 },
                {"one", 1 },
                {"three", 3 },
            };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            //а) Свернуть обращение к OrderBy с использованием лямбда - выражения $.

            Console.WriteLine();

            Dictionary<string, int> dict2 = new Dictionary<string, int>()
            {
                {"four", 4 },
                {"two", 2 },
                {"one", 1 },
                {"three", 3 },
            };

            foreach (var pair in dict2.OrderBy(el => el.Value))
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
    }
}
