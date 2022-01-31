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
        static void Decoding(string _first, string _second, string[] wordtomb)
        {
            string[] chartomb = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " };
            Random r = new Random();

            int min = 0;
            if (_first.Length >= _second.Length)
                min = _second.Length;
            else
                min = _first.Length;

            //delódolás
            string key = "";
            string firstMessage = "";
            string secondMessage = "";
            int firstMessWords = -1;
            int secondMessWords = -1;
            while (key.Length != min)
            {
                string firstNow = wordtomb[r.Next(0, wordtomb.Length)];
                //firstMessage += firstNow+" ";
                firstMessWords++;

                //k=o-i
                //első üzenet
                string keyNow = "";
                for (int i = 0; i < firstNow.Length; i++)
                {
                    int j = 0;
                    int k = 0;
                    while (j < chartomb.Length && firstNow[i].ToString() != chartomb[j])
                        j++;
                    while (k < chartomb.Length && _first[i].ToString() != chartomb[k])
                        k++;

                    int ertek = k - j;

                    while (ertek < 0) 
                        ertek += 27;
                    //key += chartomb[ertek];
                    keyNow += chartomb[ertek];
                }

                //i=o-k
                //második üzenet
                string secondNow = "";
                for (int i = 0; i < keyNow.Length; i++)
                {
                    int j = 0;
                    int k = 0;
                    while (j < chartomb.Length && keyNow[i].ToString() != chartomb[j])
                    {
                        j++;
                    }
                    while (k < chartomb.Length && _second[i].ToString() != chartomb[k])
                    {
                        k++;
                    }
                    int ertek = k - j;

                    while (ertek < 0)
                    {
                        ertek = ertek + 27;
                    }
                    //secondMessage += chartomb[ertek]+" ";
                    secondMessWords++;
                    secondNow += chartomb[ertek];
                }

                int index = 0;
                while (index < wordtomb.Length && wordtomb[index].Contains(secondMessage.Split(" ")[secondMessWords]))
                {
                    index++;
                }

                if (index < wordtomb.Length) 
                {
                    firstMessWords = -1;
                    secondMessWords = -1;
                }
                else
                {
                    firstMessage += firstNow;
                    secondMessage += secondNow;
                    key = keyNow;
                }
            }
        }
    }
}
