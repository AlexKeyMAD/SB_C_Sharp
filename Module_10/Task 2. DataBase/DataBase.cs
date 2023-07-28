using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Task_2.DataBase
{
    internal class DataBase
    {
        private List<Client> Data = new List<Client>();
        private List<Consultant> Users = new List<Consultant>();
        public ref List<Client> data { get { return ref Data; } }

        private string PathData = "database.json";
        private string PathUsers = "users.json";

        public void Initialosation()
        {
            if (File.Exists(PathData))
            {
                var json = File.ReadAllText(PathData);

                var _Data = JsonConvert.DeserializeObject<List<Client>>(json);

                if (_Data != null) Data = _Data;
            }

            if (File.Exists(PathUsers))
            {
                var json = File.ReadAllText(PathUsers);

                var _Users = JsonConvert.DeserializeObject<List<Consultant>>(json,new UserConverter());

                if (_Users != null) Users = _Users;

            }
        }

        ~DataBase()
        {
            SaveDataBase();
        }

        public void SaveDataBase()
        {
            var json = JsonConvert.SerializeObject(Data);

            File.WriteAllText(PathData, json);
        }

        #region Users
        /// <summary>
        /// Данный класс создан для правильной десериализации JSON, программа должна понимать какой класс в пользователе использовать
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract class JsonCreationConverter<T> : JsonConverter
        {
            protected abstract T Create(Type objectType, JObject jObject);

            public override bool CanConvert(Type objectType)
            {
                return typeof(T) == objectType;
            }

            public override object ReadJson(JsonReader reader, Type objectType,
                object existingValue, JsonSerializer serializer)
            {
                try
                {
                    var jObject = JObject.Load(reader);
                    var target = Create(objectType, jObject);
                    serializer.Populate(jObject.CreateReader(), target);
                    return target;
                }
                catch (JsonReaderException)
                {
                    return null;
                }
            }

            public override void WriteJson(JsonWriter writer, object value,
                JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }

        public class UserConverter : JsonCreationConverter<Consultant>
        {
            protected override Consultant Create(Type objectType, JObject jObject)
            {
                switch ((Roles)jObject["role"].Value<int>())
                {
                    case Roles.CONSULTANT:
                        return new Consultant(jObject["name"].Value<string>());
                    case Roles.MANAGER:
                        return new Manager(jObject["name"].Value<string>());
                }
                return null;
            }
        }

        private void SaveUsers()
        {
            var json = JsonConvert.SerializeObject(Users, Formatting.Indented);

            File.WriteAllText(PathUsers, json);
        }

        private int FindUser(string Name)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].GetName() == Name)
                {
                    return i;
                }
            }

            return -1;
        }

        public Consultant Identification()
        {
            Console.WriteLine("Введите имя пользователя:");
            var name = Console.ReadLine();

            var fnd = FindUser(name);

            if (fnd == -1)
            {
                Console.WriteLine("Выберите роль пользователя:");

                int n = 0;

                foreach (var role in Enum.GetValues(typeof(Roles)))
                {
                    n++;
                    Console.WriteLine($"{n}. {role.ToString()}");
                }

                int r = int.Parse(Console.ReadLine());

                r = r > n ? 1 : r;

                Consultant usr = null;

                if ((Roles)r == Roles.CONSULTANT) usr = new Consultant(name);
                else usr = new Manager(name);

                Users.Add(usr);

                SaveUsers();

                return usr;
            }
            else
            {
                return Users[fnd];
            }
        }
        #endregion

    }
}
