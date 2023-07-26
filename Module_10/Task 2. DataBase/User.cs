﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task_2.DataBase
{
    enum Roles
    {
        CONSULTANT = 1,
        MANAGER = 2
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
    }

    [JsonObject(MemberSerialization.Fields)]
    internal class Manager : Consultant
    {
        public Manager(string n):base(n) { }
        
    }
}
