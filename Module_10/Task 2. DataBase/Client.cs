using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.DataBase
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

        public Client()
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
        }

        public void Change(Consultant usr)
        {
            var str = string.Empty;

            if (usr is Manager)
            {
                Console.Write("Фамилия: ");
                str = Console.ReadLine();
                if (str != string.Empty) FamilyName = str;

                Console.Write("Имя: ");
                str = Console.ReadLine();
                if (str != string.Empty) Name = str;

                Console.Write("Отчество: ");
                str = Console.ReadLine();
                if (str != string.Empty) Surname = str;

                Console.Write("Серия паспорта: ");
                str = Console.ReadLine();
                if (str != string.Empty) PassportSeries = str;

                Console.Write("Номер паспорта: ");
                str = Console.ReadLine();
                if (str != string.Empty) PassportNumber = str;
            }

            Console.WriteLine("Номер телефона:");
            str = Console.ReadLine();
            if (str != string.Empty) PhoneNumber = str;
          
        }

        public string Info(Consultant usr)
        {
            string str = string.Empty;

            str += FamilyName + "\t";
            str += Name + "\t";
            str += Surname + "\t";
            str += PhoneNumber + "\t";
            if (usr is Consultant)
            {
                str += "*****" + "\t";
                str += "********" + "\n";
            }
            else
            {
                str += PassportSeries + "\t";
                str += PassportNumber + "\n";
            }

            return str;
        }
    }
}
