using System;
using System.Collections.Generic;
using System.Linq;

namespace UP
{
    public class ShelterAnimal
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public bool HasVaccinations { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool IsAdopted { get; set; }

        public ShelterAnimal(string name, string species, int age, bool vaccinated, DateTime admission)
        {
            Name = name;
            Species = species;
            Age = age;
            HasVaccinations = vaccinated;
            AdmissionDate = admission;
            IsAdopted = false;
        }

        public void Adopt()
        {
            IsAdopted = true;
            Console.WriteLine($"Животное {Name} забрали домой!");
        }

        public void DisplayInfo()
        {
            string status = IsAdopted ? "Забрали домой" : "В приюте";
            string vaccines = HasVaccinations ? "Да" : "Нет";

            Console.WriteLine($"{Name} ({Species}), {Age} лет");
            Console.WriteLine($"Прививки: {vaccines}, Дата поступления: {AdmissionDate:dd.MM.yyyy}");
            Console.WriteLine($"Статус: {status}");
            Console.WriteLine();
        }
    }

    internal class zadacha5
    {
        static List<ShelterAnimal> animals = new List<ShelterAnimal>();

        static void Main(string[] args)
        {
            animals.Add(new ShelterAnimal("Барсик", "Кот", 2, true, new DateTime(2024, 1, 15)));
            animals.Add(new ShelterAnimal("Шарик", "Собака", 3, false, new DateTime(2024, 2, 20)));

            while (true)
            {
                Console.WriteLine("ПИТОМНИК ДЛЯ ЖИВОТНЫХ");
                Console.WriteLine("1. Добавить животное");
                Console.WriteLine("2. Показать всех животных");
                Console.WriteLine("3. Животные без прививок");
                Console.WriteLine("4. Поиск по кличке");
                Console.WriteLine("5. Забрать домой");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите действие: ");

                switch (Console.ReadLine())
                {
                    case "1": AddAnimal(); break;
                    case "2": ShowAllAnimals(); break;
                    case "3": ShowUnvaccinated(); break;
                    case "4": SearchByName(); break;
                    case "5": AdoptAnimal(); break;
                    case "6": return;
                    default: Console.WriteLine("Неверный выбор!"); break;
                }
            }
        }

        static void AddAnimal()
        {
            Console.Write("Кличка: "); string name = Console.ReadLine();
            Console.Write("Вид: "); string species = Console.ReadLine();
            Console.Write("Возраст: "); int age = int.Parse(Console.ReadLine());
            Console.Write("Прививки (да/нет): "); bool vaccines = Console.ReadLine().ToLower() == "да";
            Console.Write("Дата поступления (дд.мм.гггг): "); DateTime date = DateTime.Parse(Console.ReadLine());

            animals.Add(new ShelterAnimal(name, species, age, vaccines, date));
            Console.WriteLine("Животное добавлено!\n");
        }

        static void ShowAllAnimals()
        {
            if (!animals.Any()) { Console.WriteLine("Животных нет.\n"); return; }
            foreach (var animal in animals) animal.DisplayInfo();
        }

        static void ShowUnvaccinated()
        {
            var unvaccinated = animals.Where(a => !a.HasVaccinations && !a.IsAdopted).ToList();
            if (unvaccinated.Any())
            {
                Console.WriteLine("ЖИВОТНЫЕ БЕЗ ПРИВИВОК:");
                foreach (var animal in unvaccinated) animal.DisplayInfo();
            }
            else Console.WriteLine("Все животные привиты.\n");
        }

        static void SearchByName()
        {
            Console.Write("Введите кличку: ");
            string name = Console.ReadLine();
            var found = animals.FindAll(a => a.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);

            if (found.Any())
            {
                Console.WriteLine("НАЙДЕННЫЕ ЖИВОТНЫЕ:");
                foreach (var animal in found) animal.DisplayInfo();
            }
            else Console.WriteLine("Животное не найдено.\n");
        }

        static void AdoptAnimal()
        {
            Console.Write("Кличка животного: ");
            string name = Console.ReadLine();
            var animal = animals.Find(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && !a.IsAdopted);

            if (animal != null) animal.Adopt();
            else Console.WriteLine("Животное не найдено или уже забрано.\n");
        }
    }
}