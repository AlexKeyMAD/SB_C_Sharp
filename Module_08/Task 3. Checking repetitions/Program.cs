using System;
using System.Collections.Generic;

namespace Task_3.Checking_repetitions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<int>();

            while (true)
            {
                Console.WriteLine("Введите число:");

                var str = Console.ReadLine();

                if (str == string.Empty) break;

                int num = int.Parse(str);

                if (set.Add(num)) Console.WriteLine("Число добавлено в список");
                else Console.WriteLine("Число уже присутствует в списке");
            }

            Console.WriteLine("Список:");

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();

        }
    }
}
