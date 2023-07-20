using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Phonebook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new Dictionary<string, string>();

            var str1 = string.Empty;
            var str2 = string.Empty;

            while (true)
            {
                Console.WriteLine("Введите номер телефона");

                str1 = Console.ReadLine();

                if (str1 == " " || str1 == string.Empty) break;

                Console.WriteLine("Введите ФИО");

                str2 = Console.ReadLine();

                if (str2 == " " || str2 == string.Empty) break;

                phonebook.Add(str1, str2);
            }

            while (true)
            {
                Console.WriteLine("Введите номер телефона для поиска");

                str1 = Console.ReadLine();

                if (str1 == " " || str1 == string.Empty) break;

                if (phonebook.TryGetValue(str1, out str2))
                {
                    Console.WriteLine(str2);
                }
                else Console.WriteLine($"ФИО по номеру {str1} не найдено");
            }

        }
    }
}
