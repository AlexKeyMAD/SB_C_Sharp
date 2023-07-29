using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.DataBase
{
    [JsonObject(MemberSerialization.Fields)]
    internal class Log
    {
        private DateTime dateTime { get; set; }
        private string dataType { get; set; }
        private string type { get; set; }
        private IUser user { get; set; }

        public Log(string dataType, string type, IUser user)
        {
            this.dateTime = DateTime.Now;
            this.dataType = dataType;
            this.type = type;
            this.user = user;
        }

        public override string ToString()
        {            
            return ($"{dateTime.ToString()}/{dataType}/{type}/{user==null?"":user.ToString()}");
        }
    }
}
