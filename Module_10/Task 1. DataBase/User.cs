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
        
        public void ShowData(ref List<DataBase> data)
        {
            int num = -1;

            while (num != 0)
            {
                Console.Clear();

                for (var i = 0; i < data.Count; ++i)
                {
                    Console.WriteLine($"{i + 1}. {data[i].Info()}");
                }

                Console.WriteLine("Выбирите действие:");
                Console.WriteLine("1. Изменить");
                Console.WriteLine("0. Выход");

                num = int.Parse(Console.ReadLine());

                if (num == 1)
                {
                    Console.WriteLine($"Введите номер строки для изменения (1 - {data.Count})");
                    var index = int.Parse(Console.ReadLine());
                    if (index <= data.Count && index > 0) data[index - 1].Change();
                }
                                
            }
        }

        public string Info(DataBase data)
        {
            string str = string.Empty;

            str += data.FamilyName + "\t";
            str += Name + "\t";
            str += Surname + "\t";
            str += PhoneNumber + "\t";
            str += "*****" + "\t";
            str += "********" + "\n";

            return str;
        }
    }
}
