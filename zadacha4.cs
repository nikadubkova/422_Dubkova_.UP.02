using System;
using System.Collections.Generic;
using System.Linq;

namespace UP
{
    public class BuildingItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int MinQuantity { get; set; }

        public BuildingItem(string name, string category, decimal price, int quantity, int minQuantity)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
            MinQuantity = minQuantity;
        }

        public void Sell(int amount)
        {
            if (amount <= Quantity)
            {
                Quantity -= amount;
                Console.WriteLine($"Продано {amount} ед. товара {Name}");
                CheckStock();
            }
            else
            {
                Console.WriteLine($"Недостаточно товара {Name} на складе");
            }
        }

        public void CheckStock()
        {
            if (Quantity < MinQuantity)
            {
                Console.WriteLine($"ВНИМАНИЕ! Товар {Name} почти закончился! Осталось: {Quantity}");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{Name} ({Category})");
            Console.WriteLine($"Цена: {Price} руб., Количество: {Quantity}, Минимум: {MinQuantity}");
            Console.WriteLine();
        }
    }

    internal class zadacha4
    {
        static List<BuildingItem> items = new List<BuildingItem>();

        static void Main(string[] args)
        {
            items.Add(new BuildingItem("Молоток", "Инструмент", 500, 15, 5));
            items.Add(new BuildingItem("Краска", "Отделка", 1200, 8, 3));

            while (true)
            {
                Console.WriteLine("СТРОИТЕЛЬНЫЙ МАГАЗИН");
                Console.WriteLine("1. Добавить товар");
                Console.WriteLine("2. Показать все товары");
                Console.WriteLine("3. Продать товар");
                Console.WriteLine("4. Поиск по названию");
                Console.WriteLine("5. Удалить товар");
                Console.WriteLine("6. Проверить остатки");
                Console.WriteLine("7. Выход");
                Console.Write("Выберите действие: ");

                switch (Console.ReadLine())
                {
                    case "1": AddItem(); break;
                    case "2": ShowAllItems(); break;
                    case "3": SellItem(); break;
                    case "4": SearchByName(); break;
                    case "5": RemoveItem(); break;
                    case "6": CheckAllStock(); break;
                    case "7": return;
                    default: Console.WriteLine("Неверный выбор!"); break;
                }
            }
        }

        static void AddItem()
        {
            Console.Write("Название: "); string name = Console.ReadLine();
            Console.Write("Категория: "); string category = Console.ReadLine();
            Console.Write("Цена: "); decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Количество: "); int quantity = int.Parse(Console.ReadLine());
            Console.Write("Минимальный остаток: "); int min = int.Parse(Console.ReadLine());

            items.Add(new BuildingItem(name, category, price, quantity, min));
            Console.WriteLine("Товар добавлен!\n");
        }

        static void ShowAllItems()
        {
            if (!items.Any()) { Console.WriteLine("Товаров нет.\n"); return; }
            foreach (var item in items) item.DisplayInfo();
        }

        static void SellItem()
        {
            Console.Write("Название товара: "); string name = Console.ReadLine();
            var item = items.Find(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (item != null)
            {
                Console.Write("Количество для продажи: ");
                int amount = int.Parse(Console.ReadLine());
                item.Sell(amount);
            }
            else Console.WriteLine("Товар не найден.\n");
        }

        static void SearchByName()
        {
            Console.Write("Введите название: ");
            string name = Console.ReadLine();
            var found = items.FindAll(i => i.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);

            if (found.Any())
            {
                Console.WriteLine("НАЙДЕННЫЕ ТОВАРЫ:");
                foreach (var item in found) item.DisplayInfo();
            }
            else Console.WriteLine("Товары не найдены.\n");
        }

        static void RemoveItem()
        {
            Console.Write("Название товара для удаления: ");
            string name = Console.ReadLine();
            var item = items.Find(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (item != null) { items.Remove(item); Console.WriteLine("Товар удален!\n"); }
            else Console.WriteLine("Товар не найден.\n");
        }

        static void CheckAllStock()
        {
            Console.WriteLine("ПРОВЕРКА ОСТАТКОВ:");
            foreach (var item in items) item.CheckStock();
            Console.WriteLine();
        }
    }
}