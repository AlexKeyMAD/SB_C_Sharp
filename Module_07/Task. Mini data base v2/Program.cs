using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Mini_data_base_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            repository.ShowWorkers();

            repository.AddWorker(new Worker(false));

            Console.ReadKey();

            var list = repository.GetWorkersBetweenTwoDates(new DateTime(2023, 07, 19, 22, 50, 00), new DateTime(2023, 07, 19, 23, 00, 00));

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();

            Console.WriteLine("Введите ID для удаления");

            repository.DeleteWorker(int.Parse(Console.ReadLine()));

            Console.ReadKey();

            repository.ShowWorkers();

            Console.ReadKey();

            repository.SortByAge();
            repository.ShowWorkers();

            Console.ReadKey();
        }
    }
}
