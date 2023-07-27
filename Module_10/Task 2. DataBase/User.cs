using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task_2.DataBase
{
    enum Roles
    {
        CONSULTANT = 1,
        MANAGER = 2
    }

    [JsonObject(MemberSerialization.Fields)]
    internal class Consultant
    {
        private string name;
        public string GetName()
        {
            return name;
        }

        public Consultant(string n)
        {
            name = n;
        }

        public void ShowData(ref List<Client> data)
        {
            int num = -1;

            while (num != 0)
            {
                Console.Clear();

                for (var i = 0; i < data.Count; ++i)
                {
                    Console.WriteLine($"{i + 1}. {Info(data[i])}");
                }

                Console.WriteLine("Выбирите действие:");
                Console.WriteLine("1. Изменить");
                Console.WriteLine("0. Выход");

                num = int.Parse(Console.ReadLine());

                if (num == 1)
                {
                    Console.WriteLine($"Введите номер строки для изменения (1 - {data.Count})");
                    var index = int.Parse(Console.ReadLine());
                    if (index <= data.Count && index > 0) Change(ref data, num);
                }

            }
        }

        private string Info(Client data)
        {
            string str = string.Empty;

            str += data.FamilyName + "\t";
            str += data.Name + "\t";
            str += data.Surname + "\t";
            str += data.PhoneNumber + "\t";
            str += "*****" + "\t";
            str += "********" + "\n";

            return str;
        }

        public void Change(ref List<Client> data, int ind)
        {
            Console.WriteLine("Введите новый номер телефона:");
            var str = Console.ReadLine();

            if (str != string.Empty) data[ind].PhoneNumber = str;

        }
    }

    [JsonObject(MemberSerialization.Fields)]
    internal class Manager : Consultant
    {
        public Manager(string n) : base(n) { }

        private string Info(Client data)
        {
            string str = string.Empty;

            str += data.FamilyName + "\t";
            str += data.Name + "\t";
            str += data.Surname + "\t";
            str += data.PhoneNumber + "\t";
            str += data.PassportSeries + "\t";
            str += data.PassportNumber + "\n";

            return str;
        }

        public new void ShowData(ref List<Client> data)
        {
            int num = -1;

            while (num != 0)
            {
                Console.Clear();

                for (var i = 0; i < data.Count; ++i)
                {
                    Console.WriteLine($"{i + 1}. {Info(data[i])}");
                }

                Console.WriteLine("Выбирите действие:");
                Console.WriteLine("1. Изменить");
                Console.WriteLine("0. Выход");

                num = int.Parse(Console.ReadLine());

                if (num == 1)
                {
                    Console.WriteLine($"Введите номер строки для изменения (1 - {data.Count})");
                    var index = int.Parse(Console.ReadLine());
                    if (index <= data.Count && index > 0)
                    {
                        Console.WriteLine("РЕДАКТИРОВАНИЕ");
                        Console.WriteLine($" {num}\t{Info(data[num - 1])}");                        
                    }
                }

            }
        }

        public new void Change(ref List<Client> data, int ind)
        {
            Console.WriteLine("Фамилия:");
            var str = Console.ReadLine();
            if (str != string.Empty) data[ind].FamilyName = str;

            Console.WriteLine("Имя:");
            str = Console.ReadLine();
            if (str != string.Empty) data[ind].Name = str;

            Console.WriteLine("Отчество:");
            str = Console.ReadLine();
            if (str != string.Empty) data[ind].Surname = str;

            Console.WriteLine("Введите новый номер телефона:");
            str = Console.ReadLine();
            if (str != string.Empty) data[ind].PhoneNumber = str;

            Console.WriteLine("Серия паспорта:");
            str = Console.ReadLine();
            if (str != string.Empty) data[ind].PassportSeries = str;

            Console.WriteLine("Номер паспорта:");
            str = Console.ReadLine();
            if (str != string.Empty) data[ind].PassportNumber = str;
        }
    }
}