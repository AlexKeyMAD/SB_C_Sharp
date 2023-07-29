using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.DataBase
{
    class UnixTimeToDatetimeConverter : DateTimeConverterBase
    {
        private static readonly DateTime _epoch =
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


        public override void WriteJson(JsonWriter writer, object value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            return _epoch.AddSeconds(Convert.ToDouble(reader.Value)).ToLocalTime();
        }
    }

    [JsonObject(MemberSerialization.Fields)]
    internal class Log
    {       
        [JsonConverter(typeof(UnixTimeToDatetimeConverter))]
        private DateTime Date { get; set; }
        private string DataType { get; set; }
        private string Type { get; set; }
        private IUser User { get; set; }

        public Log(string dataType, string type, IUser user)
        {
            this.Date = DateTime.Now;
            this.DataType = dataType;
            this.Type = type;
            this.User = user;
        }

        public override string ToString()
        {            
            return ($"{Date.ToString()}/{DataType}/{Type}/{(User==null?"":User.ToString())}");
        }
    }
}
