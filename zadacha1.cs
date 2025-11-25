using System;
using System.Collections.Generic;

namespace UP
{
    public class Tourist
    {
        public string FullName { get; set; }
        public string PassportNumber { get; set; }
        public string Destination { get; set; }
        public DateTime TravelDate { get; set; }
        public int Days { get; set; }
        public decimal Price { get; set; }

        public Tourist(string fullName, string passport, string destination, DateTime date, int days, decimal price)
        {
            FullName = fullName;
            PassportNumber = passport;
            Destination = destination;
            TravelDate = date;
            Days = days;
            Price = price;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Турист: {FullName}");
            Console.WriteLine($"Паспорт: {PassportNumber}");
            Console.WriteLine($"Направление: {Destination}");
            Console.WriteLine($"Дата: {TravelDate:dd.MM.yyyy}");
            Console.WriteLine($"Дней: {Days}");
            Console.WriteLine($"Стоимость: {Price} руб.");
            Console.WriteLine();
        }
    }

    internal class zadacha1
    {
        static List<Tourist> tourists = new List<Tourist>();

        static void Main(string[] args)
        {
            tourists.Add(new Tourist("Сергеев Борис Эдуардович", "123456", "Турция", new DateTime(2024, 6, 15), 10, 50000));
            tourists.Add(new Tourist("Журавлева Анна Андреевна", "654321", "Египет", new DateTime(2024, 7, 1), 14, 75000));

            while (true)
            {
                Console.WriteLine("ТУРИСТИЧЕСКОЕ АГЕНТСТВО");
                Console.WriteLine("1. Добавить туриста");
                Console.WriteLine("2. Показать всех туристов");
                Console.WriteLine("3. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddTourist();
                        break;
                    case "2":
                        ShowAllTourists();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
        }

        static void AddTourist()
        {
            Console.Write("ФИО: ");
            string name = Console.ReadLine();
            Console.Write("Номер паспорта: ");
            string passport = Console.ReadLine();
            Console.Write("Направление: ");
            string destination = Console.ReadLine();
            Console.Write("Дата (дд.мм.гггг): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Количество дней: ");
            int days = int.Parse(Console.ReadLine());
            Console.Write("Стоимость: ");
            decimal price = decimal.Parse(Console.ReadLine());

            tourists.Add(new Tourist(name, passport, destination, date, days, price));
            Console.WriteLine("Турист добавлен!\n");
        }

        static void ShowAllTourists()
        {
            if (tourists.Count == 0)
            {
                Console.WriteLine("Список туристов пуст.\n");
                return;
            }

            Console.WriteLine("СПИСОК ТУРИСТОВ:");
            foreach (var tourist in tourists)
            {
                tourist.DisplayInfo();
            }
        }
    }
}

