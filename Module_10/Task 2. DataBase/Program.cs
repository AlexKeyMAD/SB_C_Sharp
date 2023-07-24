using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.DataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase db = new DataBase();
            db.Initialosation();

            Consultant CurentUser = db.Identification();

            db.ShowClients();

            Console.ReadKey();
        }
    }
}
