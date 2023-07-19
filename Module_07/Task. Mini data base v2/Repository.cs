using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Task.Mini_data_base_v2
{
    internal class Repository
    {        
        private string Path = "Data.txt";
        private int maxID;

        private void AddWorkerToArray(ref Worker[] workers, Worker worker)
        {
            Array.Resize(ref workers, workers.Length + 1);
            workers[workers.Length - 1] = worker;
        }
        public Worker[] GetAllWorkers()
        {
            var workers = new Worker[0];

            if (File.Exists(Path))
            {
                string[] list = File.ReadAllLines(Path);

                if (list.Count<string>() == 0) Console.WriteLine("База данных пуста!!!");
                else
                {
                    foreach (var item in list)
                    {
                        var arr = item.Split();

                        AddWorkerToArray(ref workers, new Worker());
                    }
                }
            }
            return workers;
        }

        public Worker GetWorkerById(int id)
        {
            var workers = GetAllWorkers();

            foreach (var item in workers)
            {
                if (item.id == id) return item;
            }

            return new Worker();
        }

        public void DeleteWorker(int id)
        {
            // считывается файл, находится нужный Worker
            // происходит запись в файл всех Worker,
            // кроме удаляемого
        }

        public void AddWorker(Worker worker)
        {
            // присваиваем worker уникальный ID,
            // дописываем нового worker в файл
        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            // здесь происходит чтение из файла
            // фильтрация нужных записей
            // и возврат массива считанных экземпляров
            return new Worker[0];
        }
    }
}
