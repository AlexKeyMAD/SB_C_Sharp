using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Random_matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк в матрице");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество столбцов в матрице");
            int b = int.Parse(Console.ReadLine());

            int[,] matrix = new int[a, b];

            var rnd = new Random();

            //заполнение матрицы
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next();
                }
            }

            //вывод матрицы
            Console.WriteLine("Результат:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j != 0) Console.Write("\t");
                    Console.Write("{0:# ### ### ###}", matrix[i, j]);
                }
                Console.Write("\n");
            }

            Console.ReadKey();
        }
    }
}
