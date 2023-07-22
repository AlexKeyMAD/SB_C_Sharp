using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task_1.DataBase
{
    internal class DataBase
    {
        private List<Client> Data = new List<Client>();
        private List<User> Users = new List<User>();

        private string PathData = "database.json";
        private string PathUsers = "users.json";

        DataBase()
        {
            if (File.Exists(PathData))
            {
                var json = File.ReadAllText(PathData);

                Data = JsonConvert.DeserializeObject<List<Client>>(json);
            }

            if (File.Exists(PathUsers))
            {
                var json = File.ReadAllText(PathUsers);

                Users = JsonConvert.DeserializeObject<List<User>>(json);
            }
        }
        ~DataBase()
        {
            SaveDataBase();
        }

        private void SaveDataBase()
        {
            var json = JsonConvert.SerializeObject(Data);

            File.WriteAllText(PathData, json);
        }

        #region Users
        private void SaveUsers()
        {
            var json = JsonConvert.SerializeObject(Users);

            File.WriteAllText(PathUsers, json);
        }

        public void NewUser()
        {
            Console.WriteLine("Введите имя пользователя:");
            var name = Console.ReadLine();

            Console.WriteLine("Выберите роль пользователя:");

            int n = 0;

            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                n++;
                Console.WriteLine($"{n}. {role.ToString()}");
            }

            SaveUsers();
        }
        #endregion
    }
}
