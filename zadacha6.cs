using System;
using System.Collections.Generic;
using System.Linq;

namespace UP
{
    public class TaxiCar
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public bool IsWorking { get; set; }
        public string Driver { get; set; }

        public TaxiCar(string brand, string model, int year, int mileage, string driver)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Mileage = mileage;
            Driver = driver;
            IsWorking = true;
        }

        public void SetStatus(bool working)
        {
            IsWorking = working;
            string status = working ? "в работе" : "на ремонте";
            Console.WriteLine($"Автомобиль {Brand} {Model} теперь {status}");
        }

        public void UpdateMileage(int newMileage)
        {
            if (newMileage >= Mileage)
            {
                Mileage = newMileage;
                Console.WriteLine($"Пробег обновлен: {Mileage} км");
            }
            else
            {
                Console.WriteLine("Новый пробег не может быть меньше текущего!");
            }
        }

        public void DisplayInfo()
        {
            string status = IsWorking ? "В работе" : "На ремонте";
            Console.WriteLine($"{Brand} {Model} ({Year} г.)");
            Console.WriteLine($"Пробег: {Mileage} км, Водитель: {Driver}");
            Console.WriteLine($"Статус: {status}");
            Console.WriteLine();
        }
    }

    internal class zadacha6
    {
        static List<TaxiCar> cars = new List<TaxiCar>();

        static void Main(string[] args)
        {
            cars.Add(new TaxiCar("Toyota", "Camry", 2020, 50000, "Иванов Иван"));
            cars.Add(new TaxiCar("Hyundai", "Solaris", 2019, 75000, "Петров Петр"));

            while (true)
            {
                Console.WriteLine("ТАКСОПАРК");
                Console.WriteLine("1. Добавить автомобиль");
                Console.WriteLine("2. Показать все автомобили");
                Console.WriteLine("3. Изменить статус");
                Console.WriteLine("4. Обновить пробег");
                Console.WriteLine("5. Поиск по водителю");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите действие: ");

                switch (Console.ReadLine())
                {
                    case "1": AddCar(); break;
                    case "2": ShowAllCars(); break;
                    case "3": ChangeStatus(); break;
                    case "4": UpdateMileage(); break;
                    case "5": SearchByDriver(); break;
                    case "6": return;
                    default: Console.WriteLine("Неверный выбор!"); break;
                }
            }
        }

        static void AddCar()
        {
            Console.Write("Марка: "); string brand = Console.ReadLine();
            Console.Write("Модель: "); string model = Console.ReadLine();
            Console.Write("Год: "); int year = int.Parse(Console.ReadLine());
            Console.Write("Пробег: "); int mileage = int.Parse(Console.ReadLine());
            Console.Write("Водитель: "); string driver = Console.ReadLine();

            cars.Add(new TaxiCar(brand, model, year, mileage, driver));
            Console.WriteLine("Автомобиль добавлен!\n");
        }

        static void ShowAllCars()
        {
            if (!cars.Any()) { Console.WriteLine("Автомобилей нет.\n"); return; }
            foreach (var car in cars) car.DisplayInfo();
        }

        static void ChangeStatus()
        {
            Console.Write("Марка автомобиля: "); string brand = Console.ReadLine();
            Console.Write("Модель: "); string model = Console.ReadLine();
            var car = cars.Find(c => c.Brand == brand && c.Model == model);

            if (car != null)
            {
                Console.Write("Статус (1-работает, 0-ремонт): ");
                bool status = Console.ReadLine() == "1";
                car.SetStatus(status);
            }
            else Console.WriteLine("Автомобиль не найден.\n");
        }

        static void UpdateMileage()
        {
            Console.Write("Марка автомобиля: "); string brand = Console.ReadLine();
            Console.Write("Модель: "); string model = Console.ReadLine();
            var car = cars.Find(c => c.Brand == brand && c.Model == model);

            if (car != null)
            {
                Console.Write("Новый пробег: ");
                int mileage = int.Parse(Console.ReadLine());
                car.UpdateMileage(mileage);
            }
            else Console.WriteLine("Автомобиль не найден.\n");
        }

        static void SearchByDriver()
        {
            Console.Write("Введите ФИО водителя: ");
            string driver = Console.ReadLine();
            var found = cars.FindAll(c => c.Driver.IndexOf(driver, StringComparison.OrdinalIgnoreCase) >= 0);

            if (found.Any())
            {
                Console.WriteLine("НАЙДЕННЫЕ АВТОМОБИЛИ:");
                foreach (var car in found) car.DisplayInfo();
            }
            else Console.WriteLine("Автомобили не найдены.\n");
        }
    }
}