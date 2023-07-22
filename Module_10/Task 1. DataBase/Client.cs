using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.DataBase
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

        public string Info(Roles role = Roles.MANAGER)
        {
            string str = string.Empty;

            str += FamilyName + "\t";
            str += Name + "\t";
            str += Surname + "\t";
            str += PhoneNumber + "\t";
            str += (role == Roles.MANAGER ? "*****" : PassportSeries) + "\t";
            str += (role == Roles.MANAGER ? "********" : PassportNumber) + "\n";

            return str;

        }
    }
}
