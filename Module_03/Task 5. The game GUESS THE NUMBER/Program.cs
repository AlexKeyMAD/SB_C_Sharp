using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5.The_game_GUESS_THE_NUMBER
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите максимальное число диапазона: ");
            int max = int.Parse(Console.ReadLine());

            var rnd = new Random();

            int number = rnd.Next(max + 1);

            while (true)
            {
                Console.WriteLine("Введите число: ");
                var str = Console.ReadLine();

                if (str == "\n" || str == " ") break;

                int num = int.Parse(str);

                if (num == number)
                {
                    Console.WriteLine("Поздравляю!!! Вы угадали!!!");
                    break;
                }
                //можно использовать else if, но мне так показалось красивей
                if (num > number) Console.WriteLine($"Загаданное число меньше {num}");
                else Console.WriteLine($"Загаданное число больше {num}");
            }

            Console.WriteLine($"Загаданое число: {number}");
            Console.WriteLine("Игра окончена");
            Console.ReadKey();
        }
    }
}
