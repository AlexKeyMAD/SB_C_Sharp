using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Task_1.DataBase
{
    enum Roles
    {
        CONSULTANT = 1
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
                    Console.WriteLine($"Введите номер строки для изменения (1 - {data.Count})");
                    var index = int.Parse(Console.ReadLine());
                    if (index <= db.data.Count && index > 0) Change(ref db, num);
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

            if (str != string.Empty) db.data[ind].PhoneNumber = str;

            db.SaveDataBase();
        }
    }
}
