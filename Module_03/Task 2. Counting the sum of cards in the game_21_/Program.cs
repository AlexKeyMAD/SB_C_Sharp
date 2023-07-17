using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Counting_the_sum_of_cards_in_the_game_21_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приветствуем Вас в нашем казино!");

            Console.WriteLine("Введите количество карт: ");

            int num = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Введите карту №{i + 1}: ");
                string str = Console.ReadLine();

                switch (str)
                {
                    case "J":
                        sum+=10;
                        break;
                    case "Q":
                        sum += 10;
                        break;
                    case "K":
                        sum += 10;
                        break;
                    case "T":
                        sum += 10;
                        break;
                    default:
                        sum += int.Parse(str);
                        break;

                }
            }

            Console.WriteLine($"Сумма карт равна {sum}");
            Console.ReadKey();
            
        }
    }
}
