using System;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            string key = Console.ReadLine().ToLower();

            Console.WriteLine(IsInputLegit(input, key));
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

                if (i < _input.Length && j < _key.Length)
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
    }
}
