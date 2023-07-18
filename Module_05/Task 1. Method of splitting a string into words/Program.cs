using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Method_of_splitting_a_string_into_words
{
    internal class Program
    {
        static void AddWordToArray(ref string[] words, string word)
        {
            Array.Resize(ref words, words.Length + 1);
            words[words.Length - 1] = word;
        }

        static string[] GetArrayWords(string text)
        {
            string str = string.Empty;

            string[] arr = new string[0];

            for (int i = 0; i < text.Length; ++i)
            {
                if (text[i] == ' ')
                {
                    AddWordToArray(ref arr, str);
                    str = string.Empty;
                }
                else
                {
                    str += text[i];
                }
            }

            if (str != string.Empty) AddWordToArray(ref arr, str);

            return arr;
        }

        static void PrintStringArray(string[] arr)
        {
            for (int i = 0;i < arr.Length; ++i)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите предложение:");

            string str = Console.ReadLine();

            var arr = GetArrayWords(str);

            PrintStringArray(arr);

            Console.ReadKey();
        }
    }
}
