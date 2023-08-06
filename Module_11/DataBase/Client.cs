using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDataBase
{
    [JsonObject(MemberSerialization.Fields)]
    internal class Client
    {
        public string FamilyName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public Log ChangeLog { get; set; }

        public Client(Consultant usr)
        {

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

            ChangeLog = new Log("All", "Создание", usr);
        }

    }
}
