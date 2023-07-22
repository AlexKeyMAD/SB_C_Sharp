using System;

namespace Task.Mini_data_base_v2
{
    internal struct Worker
    {
        public Worker(string Name, string Age, string Height, string Birthday, string Place)
        {
            id = 0;
            Date = DateTime.Now;
            this.Name = Name;
            this.Age = int.Parse(Age);
            this.Height = int.Parse(Height);
            this.Birthday = DateTime.Parse(Birthday);
            this.Place = Place;
        }
               

        public int id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime Birthday { get; set; }
        public string Place { get; set; }

        /// <summary>
        /// Перегружаем метод ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = id.ToString() + "#" +
                        Date.ToString("dd.MM.yyyy HH:mm") + "#" +
                        Name + "#" + 
                        Age.ToString() + "#" +
                        Height.ToString() + "#" +
                        Birthday.ToString("dd.MM.yyyy") + "#" +
                        Place;

            return str;
        }

    }
}
