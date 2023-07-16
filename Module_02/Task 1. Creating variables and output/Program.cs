using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Creating_variables_and_output
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fullName = "Иванов Иван Иванович";
            var age = 35;
            var eMile = "ivanov_i_i@mail.ru";
            float pointsProg = 25.0f;
            float pointsMath = 24.5f;
            float pointsPhys = 30.1f;

            string patern = "Ф. И. О.: {0}\nВозраст: {1}\nEmail: {2}\nБаллы по программированию: {3}\nБаллы по математике: {4}\nБаллы по физике: {5}";

            Console.WriteLine(patern,
                            fullName,age,eMile,pointsProg,pointsMath,pointsPhys);

            fullName = "Петров Пётр Петрович";
            age = 41;
            eMile = "petrov_p_p@mail.ru";
            pointsProg = 12;
            pointsMath = 4;
            pointsPhys = 3;

            Console.WriteLine(patern,
                            fullName, age, eMile, pointsProg, pointsMath, pointsPhys);

            fullName = "Сидоров Николай Андреевич";
            age = 18;
            eMile = "sidorov_n_a@mail.ru";
            pointsProg = 32.5f;
            pointsMath = 30.9f;
            pointsPhys = 33.0f;

            Console.WriteLine($"Ф. И. О.: {fullName}\nВозраст: {age}\nEmail: {eMile}\nБаллы по программированию: {pointsProg}\nБаллы по математике: {pointsMath}\nБаллы по физике: {pointsPhys}");

            Console.ReadKey();

        }
    }
}
