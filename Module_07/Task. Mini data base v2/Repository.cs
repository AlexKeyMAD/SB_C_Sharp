using System;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Xml.Linq;

namespace Task.Mini_data_base_v2
{
    internal class Repository
    {        
        private string Path = "Data.txt";
        private int maxID;

        /// <summary>
        /// Добавляется работник в массив с автоматическим расширением массива на 1 (типа динамический массив)
        /// </summary>
        /// <param name="workers"></param>
        /// <param name="worker"></param>
        private void AddWorkerToArray(ref Worker[] workers, Worker worker)
        {
            Array.Resize(ref workers, workers.Length + 1);
            workers[workers.Length - 1] = worker;
        }

        /// <summary>
        /// Записывается массив работников в файл
        /// </summary>
        /// <param name="workers"></param>
        private void WriteData(Worker[] workers)
        {

            using (StreamWriter sw = new StreamWriter(Path,false))
            {
                for (int i = 0; i < workers.Length; ++i)
                {
                    sw.WriteLine(workers[i].ToString());
                }
                sw.Close();
            }
        }

        /// <summary>
        /// Читаем данные из файла и возвращаем массив работников
        /// </summary>
        /// <returns></returns>
        public Worker[] GetAllWorkers()
        {
            var workers = new Worker[0];

            if (File.Exists(Path))
            {
                string[] list = File.ReadAllLines(Path);

                if (list.Count<string>() == 0) Console.WriteLine("База данных пуста!!!");
                else
                {
                    maxID = int.MinValue;
                    foreach (var item in list)
                    {
                        var arr = item.Split('#');

                        int _id = int.Parse(arr[0]);

                        maxID = _id > maxID ? _id : maxID;

                        CultureInfo provider = new CultureInfo("en-US");

                        AddWorkerToArray(ref workers, new Worker()
                                            {
                                                id = _id,
                                                Date = DateTime.ParseExact(arr[1],"dd.MM.yyyy HH:mm",provider ),
                                                Name = arr[2],
                                                Age = int.Parse(arr[3]),
                                                Height = int.Parse(arr[4]),
                                                Birthday = DateTime.ParseExact(arr[5], "dd.MM.yyyy", provider),
                                                Place = arr[6]
                                            }
                                        );
                    }
                }
            }
            return workers;
        }

        /// <summary>
        /// выводим в консоль содержимое файла работников
        /// </summary>
        public void ShowWorkers()
        {
            var workers = GetAllWorkers();
            
            Console.Clear();

            if (workers.Length == 0)
            {
                Console.WriteLine("Нет работников");
                return;
            }

            foreach (var item in workers)
            {
                Console.WriteLine(item.ToString());
            }
        }

        /// <summary>
        /// Получаем работника по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Worker GetWorkerById(int id)
        {
            var workers = GetAllWorkers();

            foreach (var item in workers)
            {
                if (item.id == id) return item;
            }

            return new Worker();
        }

        /// <summary>
        /// Удаляем работника по ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWorker(int id)
        {
            var workers = GetAllWorkers();

            Worker[] newWorkers = new Worker[0];

            foreach (var item in workers)
            {
                if (item.id != id)
                {
                    AddWorkerToArray(ref newWorkers, item);
                }
            }

            if (workers.Length == newWorkers.Length)
            {
                Console.WriteLine($"Работник с ID {id} не найден");
                return;
            }

            WriteData( newWorkers );
        }

        /// <summary>
        /// Добавляем работника
        /// </summary>
        /// <param name="worker"></param>
        public void AddWorker(Worker worker)
        {
            var workers = GetAllWorkers();
            worker.id = maxID + 1;
            worker.Date = DateTime.Now;

            AddWorkerToArray(ref workers, worker);

            WriteData(workers);

        }

        public void AddNewWorker()
        {
            Console.WriteLine("Введите данные:");
            Console.Write("Ф.И.О.: ");
            string Name = Console.ReadLine();
            Console.Write("Возраст: ");
            string Age = Console.ReadLine();
            Console.Write("Рост: ");
            string Height = Console.ReadLine();
            Console.Write("Дата рождения: ");
            string Birthday = Console.ReadLine();
            Console.Write("Место рождения: ");
            string Place = Console.ReadLine();

            AddWorker(new Worker(Name, Age, Height, Birthday, Place));
        }

        /// <summary>
        /// получение массива работников созданых в диапазоне дат
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            var workers = GetAllWorkers();

            Worker[] findWorkers = new Worker[0];

            foreach (var item in workers)
            {
                if (item.Date >= dateFrom && item.Date <= dateTo)
                {
                    AddWorkerToArray(ref findWorkers, item);
                }
            }

            return findWorkers;
        }

        /// <summary>
        /// Сортировка массива работников по возрасту
        /// </summary>
        public void SortByAge()
        {
            var workers = GetAllWorkers();
            
            Array.Sort<Worker>(workers,CompareByAge);

            WriteData(workers);
        }

        /// <summary>
        /// Компоратор для сортировки по возврасту
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int CompareByAge(Worker x, Worker y)
        {
            if (x.Age == y.Age) return 0;
            else
            {
                if (x.Age > y.Age) return 1;
                else return -1;
            }
        }
    }
}
