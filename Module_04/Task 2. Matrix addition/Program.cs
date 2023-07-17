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

            int[,] matrixA = new int[a, b];
            int[,] matrixB = new int[a, b];
            int[,] matrixC = new int[a, b];

            var rnd = new Random();

            //заполнение матриц
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    matrixA[i, j] = rnd.Next();
                    matrixB[i, j] = rnd.Next();
                    matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }

            //Сложение матриц A+B=C
            Console.WriteLine("Результат:");
            WriteMatrix(matrixA);
            Console.WriteLine("+");
            WriteMatrix(matrixB);
            Console.WriteLine("=");
            WriteMatrix(matrixC);

            Console.ReadKey();
        }

        static void WriteMatrix(int[,] matrix)
        {
            //вывод матрицы
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j != 0) Console.Write("\t");
                    Console.Write("{0:n0}", matrix[i, j]);

                }
                Console.Write("\n");
            }
        }
    }
}
