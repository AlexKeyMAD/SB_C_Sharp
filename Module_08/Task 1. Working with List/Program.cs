using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Working_with_List
{
    internal class Program
    {
        /// <summary>
        /// Заполнение списка
        /// </summary>
        /// <param name="list">Список по ссылке</param>
        /// <param name="amount">количество создаваемых элементов</param>
        /// <param name="from">минимальное заполняемое значение (включительно)</param>
        /// <param name="to">максимальное заполняемое значение (включительно)</param>
        static void CompleteTheList(ref List<int> list,int amount, int from, int to)
        {
            var rnd = new Random();

            int i = 0;

            while (i < amount)
            {
                list.Add(rnd.Next(from,to + 1));
                i++;
            }
        }

        /// <summary>
        /// Удаление диапазона значений из списка 
        /// </summary>
        /// <param name="list">Список по ссылке</param>
        /// <param name="from">минимальное удаляемое значение (включительно)</param>
        /// <param name="to">максимальное удаляемое значение (включительно)</param>
        static void RemoveFromListValueRange(ref List<int> list, int from, int to)
        {
            for (int i = list.Count - 1; i >= 0; --i)
            {
                if (list[i] >= from && list[i] <= to)
                {
                    list.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Вывод в консоль списка
        /// </summary>
        /// <param name="list">Выводимый список</param>
        static void ShowList(List<int> list)
        {
            int n = 0;
            for (int i = 0; i < list.Count; ++i)
            {
                n++;
                Console.Write(list[i].ToString());
                if (n == 5)
                { 
                    Console.Write("\n");
                    n = 0;
                }
                else Console.Write("\t\t");
            }

            Console.WriteLine($"\nРазмер списка: {list.Count.ToString()}");
        }

        static void Main(string[] args)
        {
            var list = new List<int>();

            CompleteTheList(ref list, 100, 0, 100);
            ShowList(list);

            Console.ReadKey();

            RemoveFromListValueRange(ref list, 25, 50);
            ShowList(list);

            Console.ReadKey();
        }
    }
}
