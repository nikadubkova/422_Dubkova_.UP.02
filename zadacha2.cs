using System;
using System.Collections.Generic;
using System.Linq;

namespace UP
{
    public class JewelryCustomer
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string JewelryType { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public JewelryCustomer(string name, string phone, string type, string material, decimal price, decimal discount)
        {
            FullName = name;
            Phone = phone;
            JewelryType = type;
            Material = material;
            Price = price;
            Discount = discount;
        }

        public decimal CalculateFinalPrice()
        {
            return Price * (1 - Discount / 100);
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Покупатель: {FullName}");
            Console.WriteLine($"Телефон: {Phone}");
            Console.WriteLine($"Украшение: {JewelryType}");
            Console.WriteLine($"Материал: {Material}");
            Console.WriteLine($"Цена: {Price} руб.");
            Console.WriteLine($"Скидка: {Discount}%");
            Console.WriteLine($"Итоговая стоимость: {CalculateFinalPrice():F2} руб.");
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static List<JewelryCustomer> customers = new List<JewelryCustomer>();

        static void Main(string[] args)
        {
            customers.Add(new JewelryCustomer("Смирнова Ольга Владимировна", "+79161234567", "Кольцо", "Золото", 25000, 10));
            customers.Add(new JewelryCustomer("Козлов Дмитрий Петрович", "+79035556677", "Цепочка", "Серебро", 15000, 5));

            while (true)
            {
                Console.WriteLine("МАГАЗИН ЮВЕЛИРНЫХ УКРАШЕНИЙ");
                Console.WriteLine("1. Добавить покупателя");
                Console.WriteLine("2. Показать всех покупателей");
                Console.WriteLine("3. Поиск по телефону");
                Console.WriteLine("4. Общая прибыль");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите действие: ");

                switch (Console.ReadLine())
                {
                    case "1": AddCustomer(); break;
                    case "2": ShowAllCustomers(); break;
                    case "3": SearchByPhone(); break;
                    case "4": ShowTotalProfit(); break;
                    case "5": return;
                    default: Console.WriteLine("Неверный выбор!"); break;
                }
            }
        }

        static void AddCustomer()
        {
            Console.Write("ФИО: "); string name = Console.ReadLine();
            Console.Write("Телефон: "); string phone = Console.ReadLine();
            Console.Write("Тип украшения: "); string type = Console.ReadLine();
            Console.Write("Материал: "); string material = Console.ReadLine();
            Console.Write("Цена: "); decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Скидка (%): "); decimal discount = decimal.Parse(Console.ReadLine());

            customers.Add(new JewelryCustomer(name, phone, type, material, price, discount));
            Console.WriteLine("Покупатель добавлен!\n");
        }

        static void ShowAllCustomers()
        {
            if (!customers.Any()) { Console.WriteLine("Покупателей нет.\n"); return; }
            foreach (var customer in customers) customer.DisplayInfo();
        }

        static void SearchByPhone()
        {
            Console.Write("Введите телефон: ");
            string phone = Console.ReadLine();
            var found = customers.FindAll(c => c.Phone.Contains(phone));

            if (found.Any()) foreach (var customer in found) customer.DisplayInfo();
            else Console.WriteLine("Покупатель не найден.\n");
        }

        static void ShowTotalProfit()
        {
            decimal total = customers.Sum(c => c.CalculateFinalPrice());
            Console.WriteLine($"Общая прибыль: {total:F2} руб.\n");
        }
    }
}
