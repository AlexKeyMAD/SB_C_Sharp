using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task_1.DataBase
{
    enum Roles
    {
        CONSULTANT = 1
    }

    //[JsonObject(MemberSerialization.Fields)]
    internal class User
    {
        protected string name;

        public string GetName()
        {
            return name;
        }

    }

    [JsonObject(MemberSerialization.Fields)]
    internal class Consultant : User
    {
        
        public Consultant(string n)
        {
            name = n;
        }        
    }
}
