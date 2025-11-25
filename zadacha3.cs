using System;
using System.Collections.Generic;
using System.Linq;

namespace UP
{
    public class SportCustomer
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Product { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string PaymentMethod { get; set; }

        public SportCustomer(string name, int age, string product, string size, decimal price, string payment)
        {
            FullName = name;
            Age = age;
            Product = product;
            Size = size;
            Price = price;
            PaymentMethod = payment;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{FullName}, {Age} лет");
            Console.WriteLine($"Товар: {Product}, Размер: {Size}");
            Console.WriteLine($"Цена: {Price} руб., Оплата: {PaymentMethod}");
            Console.WriteLine();
        }
    }

    internal class zadacha3
    {
        static List<SportCustomer> customers = new List<SportCustomer>();

        static void Main(string[] args)
        {
            customers.Add(new SportCustomer("Алексеев Максим Викторович", 25, "Кроссовки", "42", 5000, "Карта"));
            customers.Add(new SportCustomer("Орлова София Ивановна", 19, "Футболка", "M", 2500, "Наличные"));

            while (true)
            {
                Console.WriteLine("МАГАЗИН СПОРТИВНОЙ ОДЕЖДЫ");
                Console.WriteLine("1. Добавить покупателя");
                Console.WriteLine("2. Поиск по возрасту");
                Console.WriteLine("3. Сортировка по цене");
                Console.WriteLine("4. Показать всех");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите действие: ");

                switch (Console.ReadLine())
                {
                    case "1": AddCustomer(); break;
                    case "2": SearchByAge(); break;
                    case "3": SortByPrice(); break;
                    case "4": ShowAllCustomers(); break;
                    case "5": return;
                    default: Console.WriteLine("Неверный выбор!"); break;
                }
            }
        }

        static void AddCustomer()
        {
            Console.Write("ФИО: "); string name = Console.ReadLine();
            Console.Write("Возраст: "); int age = int.Parse(Console.ReadLine());
            Console.Write("Товар: "); string product = Console.ReadLine();
            Console.Write("Размер: "); string size = Console.ReadLine();
            Console.Write("Цена: "); decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Способ оплаты: "); string payment = Console.ReadLine();

            customers.Add(new SportCustomer(name, age, product, size, price, payment));
            Console.WriteLine("Покупатель добавлен!\n");
        }

        static void SearchByAge()
        {
            Console.Write("Введите возраст: ");
            int age = int.Parse(Console.ReadLine());
            var found = customers.FindAll(c => c.Age == age);

            if (found.Any()) foreach (var customer in found) customer.DisplayInfo();
            else Console.WriteLine("Покупатели не найдены.\n");
        }

        static void SortByPrice()
        {
            var sorted = customers.OrderByDescending(c => c.Price).ToList();
            Console.WriteLine("ПОКУПАТЕЛИ ОТСОРТИРОВАНЫ ПО ЦЕНЕ:");
            foreach (var customer in sorted) customer.DisplayInfo();
        }

        static void ShowAllCustomers()
        {
            if (!customers.Any()) { Console.WriteLine("Покупателей нет.\n"); return; }
            foreach (var customer in customers) customer.DisplayInfo();
        }
    }

}
