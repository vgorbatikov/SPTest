using SPTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SPTest.Controller
{
    class MainMenuController
    {
        public static List<Option> options;

        public static void BuildMainMenu()
        {
            // Опции главного меню
            MainMenuController.options = new List<Option>
            {
                new Option("Список товарных наименований", () => ProductController.GetProductList()),
                new Option("Создать товар", () => ProductController.AddProduct()),
                new Option("Удалить товар", () => ProductController.DeleteProduct()),
                new Option("Список аптек", () => PharmacyController.GetPharmacyList() ),
                new Option("Создать аптеку", () => PharmacyController.AddPharmacy()),
                new Option("Удалить аптеку", () => PharmacyController.DeletePharmacy()),
                new Option("Список складов", () => StockController.GetStockList()),
                new Option("Создать склад", () => StockController.AddStock()),
                new Option("Удалить склад", () => StockController.DeleteStock()),
                new Option("Список партий", () => PartController.GetPartList()),
                new Option("Создать партию", () => PartController.AddPart()),
                new Option("Удалить партию", () => PartController.DeletePart()),
                new Option("Выход", () => Environment.Exit(0)),
            };
        }

    public static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.Clear();

            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }

        // Заглушка, которую использовал в процессе разработки, и потом оставил на всякий случай
        public static void WriteTemporaryMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3000);
            MainMenuController.WriteMenu(options, options.First());
        }
    }
}
