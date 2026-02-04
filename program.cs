using System;
using System.Collections.Generic;

namespace ShoppingListApp
{
    class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

    class Program
    {
        static List<Product> shoppingList = new List<Product>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== СПИСЪК ЗА ПАЗАРУВАНЕ ===");
                Console.WriteLine("1. Добави продукт");
                Console.WriteLine("2. Покажи списъка");
                Console.WriteLine("3. Премахни продукт");
                Console.WriteLine("4. Изход");
                Console.Write("Избери опция: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        ShowList();
                        break;
                    case "3":
                        RemoveProduct();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Невалиден избор!");
                        Pause();
                        break;
                }
            }
        }

        static void AddProduct()
        {
            Console.Clear();
            Console.Write("Въведи име на продукта: ");
            string name = Console.ReadLine();

            Console.Write("Въведи количество: ");
            int quantity = int.Parse(Console.ReadLine());

            shoppingList.Add(new Product
            {
                Name = name,
                Quantity = quantity
            });

            Console.WriteLine("Продуктът е добавен успешно!");
            Pause();
        }

        static void ShowList()
        {
            Console.Clear();

            if (shoppingList.Count == 0)
            {
                Console.WriteLine("Списъкът е празен.");
            }
            else
            {
                Console.WriteLine("Текущ списък:");
                for (int i = 0; i < shoppingList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {shoppingList[i].Name} - {shoppingList[i].Quantity}");
                }
            }

            Pause();
        }

        static void RemoveProduct()
        {
            Console.Clear();
            ShowListWithoutPause();

            if (shoppingList.Count == 0)
                return;

            Console.Write("Въведи номер на продукта за премахване: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < shoppingList.Count)
            {
                shoppingList.RemoveAt(index);
                Console.WriteLine("Продуктът е премахнат.");
            }
            else
            {
                Console.WriteLine("Невалиден номер.");
            }

            Pause();
        }

        static void ShowListWithoutPause()
        {
            if (shoppingList.Count == 0)
            {
                Console.WriteLine("Списъкът е празен.");
            }
            else
            {
                for (int i = 0; i < shoppingList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {shoppingList[i].Name} - {shoppingList[i].Quantity}");
                }
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nНатисни клавиш, за да продължиш...");
            Console.ReadKey();
        }
    }
}
