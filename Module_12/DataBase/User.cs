using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TaskDataBase
{
    enum Roles
    {
        CONSULTANT = 1,
        MANAGER = 2
    }

    interface IUser
    {
        void ShowData(ref DataBase db);
        void Change(ref DataBase db, int ind);
        string ToString();
    }

    [JsonObject(MemberSerialization.Fields)]
    internal class Consultant : IUser
    {
        private string name;
        protected Roles role;
        public string GetName()
        {
            return name;
        }

        public Consultant(string n)
        {
            name = n;
            role = Roles.CONSULTANT;
        }

        public override string ToString()
        {
            return name;
        }
        public void ShowData(ref DataBase db)
        {
            int num = -1;

            while (num != 0)
            {
                Console.Clear();

                for (var i = 0; i < db.data.Count; ++i)
                {
                    Console.WriteLine($"{i + 1}. {Info(db.data[i])}");
                }

                Console.WriteLine("Выбирите действие:");
                Console.WriteLine("1. Изменить");
                Console.WriteLine("0. Выход");

                num = int.Parse(Console.ReadLine());

                if (num == 1)
                {
                    Console.WriteLine($"Введите номер строки для изменения (1 - {db.data.Count})");
                    var index = int.Parse(Console.ReadLine());
                    if (index <= db.data.Count && index > 0) Change(ref db, index - 1);
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

        public void Change(ref DataBase db, int ind)
        {
            Console.WriteLine("Введите новый номер телефона:");
            var str = Console.ReadLine();

            if (str != string.Empty)
            {
                db.data[ind].PhoneNumber = str;
                db.data[ind].ChangeLog = new Log("Номер телефона", "Изменение", this);
            }

            db.SaveDataBase();
        }
    }

    [JsonObject(MemberSerialization.Fields)]
    internal class Manager : Consultant,IUser
    {
        public Manager(string n) : base(n)
        {
            role = Roles.MANAGER;
        }

        private string Info(Client data)
        {
            string str = string.Empty;

            str += data.FamilyName + "\t";
            str += data.Name + "\t";
            str += data.Surname + "\t";
            str += data.PhoneNumber + "\t";
            str += data.PassportSeries + "\t";
            str += data.PassportNumber + "\t";
            str += data.ChangeLog == null ? "" : data.ChangeLog.ToString() + "\n";

            return str;
        }

        public new void ShowData(ref DataBase db)
        {
            int num = -1;

            while (num != 0)
            {
                Console.Clear();

                for (var i = 0; i < db.data.Count; ++i)
                {
                    Console.WriteLine($"{i + 1}. {Info(db.data[i])}");
                }

                Console.WriteLine("Выбирите действие:");
                Console.WriteLine("1. Изменить");
                Console.WriteLine("2. Создать");
                Console.WriteLine("0. Выход");

                var str = Console.ReadLine();

                num = str == string.Empty ? -1: int.Parse(str);

                if (num == 1)
                {
                    Console.WriteLine($"Введите номер строки для изменения (1 - {db.data.Count})");

                    var s = Console.ReadLine();

                    var index = s == string.Empty? 0: int.Parse(s);

                    if (index <= db.data.Count && index > 0)
                    {
                        Console.WriteLine("РЕДАКТИРОВАНИЕ");
                        Console.WriteLine($" {index}\t{Info(db.data[index - 1])}");
                        Change(ref db, index - 1);
                    }
                } else if (num == 2)
                {
                    db.data.Add(new Client(this));
                }
            }
        }

        public new void Change(ref DataBase db, int ind)
        {
            string log = string.Empty;

            Console.WriteLine("Фамилия:");
            var str = Console.ReadLine();
            if (str != string.Empty)
            {
                db.data[ind].FamilyName = str;
                log += "Фамилия";
            }

            Console.WriteLine("Имя:");
            str = Console.ReadLine();
            if (str != string.Empty)
            {
                db.data[ind].Name = str;
                log += log == string.Empty ? "," : "" + "Имя";
            }

            Console.WriteLine("Отчество:");
            str = Console.ReadLine();
            if (str != string.Empty)
            {
                db.data[ind].Surname = str;
                log += log == string.Empty ? "," : "" + "Отчество";
            }

            Console.WriteLine("Номер телефона:");
            str = Console.ReadLine();
            if (str != string.Empty)
            {
                db.data[ind].PhoneNumber = str;
                log += log == string.Empty ? "," : "" + "Номер телефона";
            }

            Console.WriteLine("Серия паспорта:");
            str = Console.ReadLine();
            if (str != string.Empty)
            {
                db.data[ind].PassportSeries = str;
                log += log == string.Empty ? "," : "" + "Серия паспорта";
            }

            Console.WriteLine("Номер паспорта:");
            str = Console.ReadLine();
            if (str != string.Empty)
            {
                db.data[ind].PassportNumber = str;
                log += log == string.Empty ? "," : "" + "Номер паспорта";
            }

            if (log != string.Empty)
            {
                db.data[ind].ChangeLog = new Log(log, "Изменение", this);
                db.SaveDataBase();
            }
        }
    }
}