using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SPTest.Model;
using SPTest.Service;

namespace SPTest.Controller
{
    class StockController
    {
        public static void GetStockList()
        {
            Console.Clear();
            Console.WriteLine("Список складов.\n");

            List<Stock> stList = new StockService().getStockList();
            foreach (Stock stock in stList)
            {
                Console.WriteLine("ID склада: " + stock.IdStock);
                Console.WriteLine("ID аптеки: " + stock.IdPharmacy);
                Console.WriteLine("Название: " + stock.Name);
            }

            Thread.Sleep(3000);
            MainMenuController.WriteMenu(MainMenuController.options, MainMenuController.options.First());

        }

        public static void AddStock()
        {
            Console.Clear();
            Console.WriteLine("Добавить склад.\n");

            try
            {
                Console.WriteLine("ID аптеки:");
                int IdPharmacy = int.Parse(Console.ReadLine());

                Console.WriteLine("Название склада:");
                String stockName = Console.ReadLine();


                Stock stock = new Stock(IdPharmacy, stockName);
                new StockService().AddStock(stock);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Thread.Sleep(3000);
            MainMenuController.WriteMenu(MainMenuController.options, MainMenuController.options.First());

        }

        public static void DeleteStock()
        {
            Console.Clear();
            Console.WriteLine("Удалить склад.\n");

            try
            {
                Console.WriteLine("Введите уникальный номер склада:");
                int idStock = int.Parse(Console.ReadLine());

                new StockService().DeleteStock(idStock);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Thread.Sleep(3000);
            MainMenuController.WriteMenu(MainMenuController.options, MainMenuController.options.First());
        }
    }
}
