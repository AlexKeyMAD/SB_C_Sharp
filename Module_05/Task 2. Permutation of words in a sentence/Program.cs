using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Permutation_of_words_in_a_sentence
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

        static string ReversWords(string text)
        {
            var arr = GetArrayWords(text);

            string str = string.Empty;

            for (int i = arr.Length; i > 0; --i)
            {
                str += arr[i - 1] + ' ';
            }

            return str;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите предложение:");

            string str = Console.ReadLine();

            Console.WriteLine(ReversWords(str));

            Console.ReadKey();
        }
    }
}
