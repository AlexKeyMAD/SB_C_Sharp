using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.DataBase
{
    [JsonObject(MemberSerialization.Fields)]
    internal class Client
    {
        private string FamilyName { get; set; }
        private string Name { get; set; }
        private string Surname { get; set; }
        private string PhoneNumber { get; set; }
        private string PassportSeries { get; set; }
        private string PassportNumber { get; set; }

        public Client(Roles role = Roles.MANAGER)
        {
            if (role == Roles.MANAGER)
            {
                return;
            }

            Console.Clear();

            Console.Write("Фамилия: ");
            var f = Console.ReadLine();
            Console.Write("Имя: ");
            var n = Console.ReadLine();
            Console.Write("Отчество: ");
            var s = Console.ReadLine();
            Console.Write("Номер телефона: ");
            var p = Console.ReadLine();
            p = p == string.Empty ? "+7 000 000 00 00" : p;
            Console.Write("Серия паспорта: ");
            var ps = Console.ReadLine();
            Console.Write("Номер паспорта: ");
            var pn = Console.ReadLine();

            FamilyName = f;
            Name = n;
            Surname = s;
            PhoneNumber = p;
            PassportSeries = ps;
            PassportNumber = pn;
        }

        public void Change(Roles role = Roles.MANAGER)
        {
            if (role == Roles.MANAGER)
            {
                Console.WriteLine("Введите новый номер телефона:");
                var str = Console.ReadLine();

                if (str != string.Empty) PhoneNumber = str;
            }
        }

        public string Info(Roles role = Roles.MANAGER)
        {
            string str = string.Empty;

            str += FamilyName + "\t";
            str += Name + "\t";
            str += Surname + "\t";
            str += PhoneNumber + "\t";
            str += (role == Roles.MANAGER ? "*****" : PassportSeries) + "\t";
            str += (role == Roles.MANAGER ? "********" : PassportNumber) + "\n";

            return str;
        }
    }
}
