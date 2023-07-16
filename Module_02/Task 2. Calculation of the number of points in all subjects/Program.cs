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
            float pointsSum = pointsProg + pointsMath + pointsPhys;

            string patern = "\nФ. И. О.: {0}\nВозраст: {1}\nEmail: {2}\nБаллы по программированию: {3}\nБаллы по математике: {4}\nБаллы по физике: {5}\n Всего баллов: {6}\nСредний балл: {7}";

            Console.WriteLine(patern,
                            fullName, age, eMile, pointsProg, pointsMath, pointsPhys, pointsSum, pointsSum / 3);

            fullName = "Петров Пётр Петрович";
            age = 41;
            eMile = "petrov_p_p@mail.ru";
            pointsProg = 12;
            pointsMath = 4;
            pointsPhys = 3;
            pointsSum = pointsProg + pointsMath + pointsPhys;

            Console.WriteLine(patern,
                            fullName, age, eMile, pointsProg, pointsMath, pointsPhys, pointsSum, pointsSum / 3);

            fullName = "Сидоров Николай Андреевич";
            age = 18;
            eMile = "sidorov_n_a@mail.ru";
            pointsProg = 32.5f;
            pointsMath = 30.9f;
            pointsPhys = 33.0f;
            pointsSum = pointsProg + pointsMath + pointsPhys;

            Console.WriteLine($"\nФ. И. О.: {fullName}\nВозраст: {age}\nEmail: {eMile}\nБаллы по программированию: {pointsProg}\nБаллы по математике: {pointsMath}\nБаллы по физике: {pointsPhys}\n Всего баллов: {pointsSum}\nСредний балл: {pointsSum / 3}");

            Console.ReadKey();

        }
    }
}
