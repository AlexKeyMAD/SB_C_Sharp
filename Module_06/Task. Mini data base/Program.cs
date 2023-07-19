using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Mini_data_base
{
    internal class Program
    {
        static string Path = "Data.txt";

        static void ShowData()
        {
            Console.Clear();

            if (File.Exists(Path))
            {
                string[] list = File.ReadAllLines(Path);

                if (list.Count<string>() == 0) Console.WriteLine("База данных пуста!!!");
                else
                {
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            else Console.WriteLine("База данных отсутствует!!!");

            Console.ReadKey();            
        }

        static void AddStringToArray(ref string[] words, string word)
        {
            Array.Resize(ref words, words.Length + 1);
            words[words.Length - 1] = word;
        }

        static void InsertData()
        {
            Console.Clear();

            string[] list = new string[0];

            if (File.Exists(Path))
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string text = sr.ReadLine();
                        AddStringToArray(ref list, text);
                    }

                    sr.Close();
                }               
            }

            string[] line = new string[7];

            Console.WriteLine("Введите данные:");
            Console.Write("Ф.И.О.: ");
            line[2] = Console.ReadLine();
            Console.Write("Возраст: ");
            line[3] = Console.ReadLine();
            Console.Write("Рост: ");
            line[4] = Console.ReadLine();
            Console.Write("Дата рождения: ");
            line[5] = Console.ReadLine();
            Console.Write("Место рождения: ");
            line[6] = Console.ReadLine();

            //ID
            line[0] = (list.Length + 1).ToString();
            //Date create
            line[1] = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

            string str = string.Join("#",line);

            using (StreamWriter sw = new StreamWriter(Path,true))
            {
                sw.WriteLine(str);
                sw.Close();
            }         
        }

        static void Main(string[] args)
        {
            string str = string.Empty;

            while (str != "0")
            {
                Console.Clear();
                //Меню
                Console.WriteLine("1 - вывести данные на экран");
                Console.WriteLine("2 - заполнить данные и добавить новую запись в базу данных");
                Console.WriteLine("0 - выход");
                Console.WriteLine("Выберите действие:");

                str = Console.ReadLine();

                switch (str)
                {
                    case "1":
                        ShowData();
                        break;
                    case "2":
                        InsertData();
                        break;
                    default:
                        break;
                }                    
            }
        }
    }
}
