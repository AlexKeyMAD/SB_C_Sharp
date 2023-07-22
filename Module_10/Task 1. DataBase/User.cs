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
        MANAGER = 1
    }

    [JsonObject(MemberSerialization.Fields)]
    internal class User
    {
        private string name;
        public string Name 
        {
            get { return name; }
            set { name = value; }
        }
        private Roles Role { get; set; }

        public User(string name, Roles role)
        {
            this.name = name;
            Role = role;
        }       
    }
}
