using System;
using System.IO;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] chartomb = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " };
            string[] wordtomb = File.ReadAllText("words.txt").Split('\n');

            //helyes értékek bekérése
            Console.Write("Első mondat: ");
            string first = Console.ReadLine();
            Console.Write("Második mondat: ");
            string second = Console.ReadLine();
            while (!IsInputLegit(first, second))
            {
                Console.Clear();
                Console.Write("Első mondat: ");
                first = Console.ReadLine();
                Console.Write("Második mondat: ");
                second = Console.ReadLine();
            }
            
            string key

        }
        static bool IsInputLegit(string _first, string _second)
        {
            int i = 0;
            int j = 0;

            while (i < _first.Length && (((int)_first[i] <= 122 && (int)_first[i] >= 97) || (int)_first[i] == 32))
            {
                i++;
            }
            while (j < _second.Length && (((int)_second[j] <= 122 && (int)_second[j] >= 97) || (int)_second[j] == 32))
            {
                j++;
            }

            if (i < _first.Length || j < _second.Length)
            {
                return false;
            }
            else return true;
        }
    }
}
