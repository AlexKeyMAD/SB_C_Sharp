using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4.The_smallest_element_in_the_sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину последовательности:");
            int size = int.Parse(Console.ReadLine());

            int min = int.MaxValue;

            string seq = string.Empty;

            for (int i = 1; i <= size; i++)
            {
                Console.WriteLine("Введите число:");
                var str = Console.ReadLine();
                
                seq += str;
                if (i != size) seq += ", ";

                int num = int.Parse(str);

                min = num < min ? num : min;
            }

            Console.WriteLine($"Минимальное число последовательности \"{seq}\" - {min}");
            Console.ReadKey();
        }
    }
}
