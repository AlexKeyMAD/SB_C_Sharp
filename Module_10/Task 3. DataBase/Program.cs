using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.DataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase db = new DataBase();
            db.Initialosation();

            IUser CurentUser = db.Identification();

            CurentUser.ShowData(ref db);

            Console.ReadKey();
        }
    }
}
