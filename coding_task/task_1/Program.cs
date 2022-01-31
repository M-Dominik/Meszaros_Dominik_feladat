using System;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] chartomb = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " };

            //helyes értékek bekérése
            Console.Write("Üzenet: ");
            string input = Console.ReadLine();
            Console.Write("Kulcs: ");
            string key = Console.ReadLine();
            while (!IsInputLegit(input, key))
            {
                Console.Clear();
                Console.Write("Üzenet: ");
                input = Console.ReadLine();
                Console.Write("Kulcs: ");
                key = Console.ReadLine();
            }

            //kódolás
            string output = Coding(input, key, chartomb);
            Console.WriteLine($"Rejtjelezett üzenet: {output}");

            //dekódolás
            string possibleInput = Decoding(output, key, chartomb);
            Console.WriteLine($"\nVisszafelytett üzenet: {possibleInput}");

        }

        static bool IsInputLegit(string _input, string _key)
        {
            if (_key.Length >= _input.Length) 
            {
                int i = 0;
                int j = 0;

                while (i < _input.Length && (((int)_input[i] <= 122 && (int)_input[i] >= 97) || (int)_input[i] == 32))
                {
                    i++;
                }
                while (j < _key.Length && (((int)_key[j] <= 122 && (int)_key[j] >= 97) || (int)_key[j] == 32))
                {
                    j++;
                }

                if (i < _input.Length || j < _key.Length)
                {
                    return false;
                }
                else return true;
            }
            else
            {
                return false;
            }
        }
        static string Coding(string _input, string _key, string[] chartomb)
        {
            string _output = "";

            for (int i = 0; i < _input.Length; i++)
            {
                int j = 0;
                int k = 0;
                while (j < chartomb.Length && _input[i].ToString() != chartomb[j])
                {
                    j++;
                }
                while (k < chartomb.Length && _key[i].ToString() != chartomb[k])
                {
                    k++;
                }
                int osszeg = j + k;
                
                while (osszeg > 26)
                {
                    osszeg = osszeg - 27;
                }
                _output += chartomb[osszeg];
            }

            return _output;
        }
        static string Decoding(string _output, string _key, string[] chartomb)
        {
            string input = "";  //itt az output
            for (int i = 0; i < _output.Length; i++)
            {
                int j = 0;
                int k = 0;
                while (j < chartomb.Length && _output[i].ToString() != chartomb[j])
                {
                    j++;
                }
                while (k < chartomb.Length && _key[i].ToString() != chartomb[k])
                {
                    k++;
                }
                int ertek = j - k;

                while (ertek < 0)
                {
                    ertek = ertek + 27;
                }
                input += chartomb[ertek];
            }
            return input;
        }
    }
}
