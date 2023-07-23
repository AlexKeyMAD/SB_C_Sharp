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

                var _Users = JsonConvert.DeserializeObject<List<User>>(json);

                if (_Users != null) Users = _Users;

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
            var json = JsonConvert.SerializeObject(Users, Formatting.Indented);

            File.WriteAllText(PathUsers, json);
        }

        private int FindUser(string Name)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Name == Name)
                {
                    return i;
                }
            }

            return -1;
        }

        public User Identification()
        {
            Console.WriteLine("Введите имя пользователя:");
            var name = Console.ReadLine();

            var fnd = FindUser(name);

            if ( fnd == -1)
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

                User usr = new User(name, (Roles)r);

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

        public void ShowClients(User usr)
        {            
            int num = -1;

            while (num != 0)
            {
                Console.Clear();

                for (var i = 0; i < Data.Count; ++i)
                {
                    Console.WriteLine($"{i + 1}. {Data[i].Info(usr.Role)}");
                }

                Console.WriteLine("Выбирите действие:");
                if (usr.Role != Roles.MANAGER) Console.WriteLine("1. Добавить");
                Console.WriteLine("2. Изменить");
                if (usr.Role != Roles.MANAGER) Console.WriteLine("3. Удалить");
                Console.WriteLine("0. Выход");

                num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        if (usr.Role != Roles.MANAGER) Data.Add(new Client(usr.Role));
                        break;
                    case 2:
                        {
                            Console.WriteLine($"Введите номер строки для изменения (1 - {Data.Count})");
                            var index = int.Parse(Console.ReadLine());
                            if (index <= Data.Count && index > 0) Data[index - 1].Change(usr.Role);
                        }
                        break;
                    case 3:
                        if (usr.Role != Roles.MANAGER)
                        {
                            Console.WriteLine($"Введите номер строки для удаления (1 - {Data.Count})");
                            var index = int.Parse(Console.ReadLine());
                            if (index <= Data.Count && index > 0) Data.RemoveAt(index - 1);
                        }    
                        break;
                    default:
                        break;
                }                    
            }
        }
    }
}
