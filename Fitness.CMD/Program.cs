using System;
using FitnessApp.BL.Controller;


namespace FitnessApp.CMD
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Добро пожаловать в приложение FitnessApp.");

            Console.WriteLine("Введите имя пользователя.");
            var name = Console.ReadLine();


            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.ReadLine();

        }

        private static DateTime ParseDateTime()
        {
            
            while (true)
            {
                Console.WriteLine("Введите дату рождения (dd.MM.yyyy): ");
                
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты.");
                }
            }
            
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}а.");
                }
            }
        }
    }
            
}