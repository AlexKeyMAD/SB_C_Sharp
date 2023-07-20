using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_4.Notebook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var doc = new XDocument();

            var notebook = new XElement("Notebook");

            var str = string.Empty;

            while (str != "выход")
            {
                Console.WriteLine("Что бы ввести данные введите \'+\', чтоб выйти введите \'выход\'");

                str = Console.ReadLine();

                if (str == "+")
                {
                    Console.WriteLine("Введите ФИО:");

                    var pers = new XElement("Person");
                    var name = new XAttribute("name",Console.ReadLine());

                    pers.Add(name);

                    //Адрес
                    var address = new XElement("Address");

                    Console.WriteLine("Введите Адрес");
                    Console.WriteLine("Улица:");
                    var Street = new XElement("Street", Console.ReadLine());
                    address.Add(Street);
                    Console.WriteLine("Номер дома");
                    var HouseNum = new XElement("HouseNumber", Console.ReadLine());
                    address.Add(HouseNum);
                    Console.WriteLine("Номер квартиры");
                    var FlatNumber = new XElement("FlatNumber", Console.ReadLine());
                    address.Add(FlatNumber);

                    pers.Add(address);

                    //Номера телефонов
                    var Phones = new XElement("Phones");

                    Console.WriteLine("Введите номера телефонов");
                    Console.WriteLine("Мобильный:");
                    var Mobile = new XElement("MobilePhone", Console.ReadLine());
                    Phones.Add(Mobile);
                    Console.WriteLine("Домашний");
                    var FlatPhone = new XElement("FlatPhone", Console.ReadLine());
                    Phones.Add(FlatPhone);
                    Console.WriteLine("Рабочий");
                    var WorkNumber = new XElement("WorkNumber", Console.ReadLine());
                    Phones.Add(WorkNumber);

                    pers.Add(Phones);

                    notebook.Add(pers);
                }
                
            }

            doc.Add(notebook);

            doc.Save("Notebook.xml");

            Console.WriteLine("Записная книжка записана!!!");
            Console.ReadKey();
        }
    }
}
