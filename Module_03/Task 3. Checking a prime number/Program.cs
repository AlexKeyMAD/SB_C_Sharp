using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Checking_a_prime_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число:");

            int num = int.Parse(Console.ReadLine());
            bool prime = true;

            for (int i = 1; i < num; ++i)
            {
                if (i != 1 && num %i == 0) prime = false;
            }

            if (prime) Console.WriteLine($"Число {num} простое");
            else Console.WriteLine($"Число {num} не является простым");

            Console.ReadKey();
        }
    }
}
