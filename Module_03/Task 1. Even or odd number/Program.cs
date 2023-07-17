using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Even_or_odd_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число: ");
            var str = Console.ReadLine();

            int num = int.Parse(str);

            if (num % 2 == 0) Console.WriteLine($"Число {num} - четное");
            else Console.WriteLine($"Число {num} - нечетное");

            Console.ReadKey();
        }
    }
}
