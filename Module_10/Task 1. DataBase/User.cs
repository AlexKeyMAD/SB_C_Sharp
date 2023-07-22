using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.DataBase
{
    enum Roles
    { 
        MANAGER
    }

    internal class User
    {
        private string Name { get; set; }
        private Roles Role { get; set; }
    }
}
