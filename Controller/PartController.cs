using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SPTest.Model;
using SPTest.Service;

namespace SPTest.Controller
{
    class PartController
    {
        public static void GetPartList()
        {
            Console.Clear();
            Console.WriteLine("Список партий.\n");

            List<Part> parts = new PartService().getPartList();
            foreach (Part part in parts)
            {
                Console.WriteLine("ID партии: " + part.IdPart);
                Console.WriteLine("ID товара: " + part.IdProduct);
                Console.WriteLine("ID склада: " + part.IdStock);
                Console.WriteLine("Количество: " + part.quantity);
            }

            Thread.Sleep(3000);
            MainMenuController.WriteMenu(MainMenuController.options, MainMenuController.options.First());

        }

        public static void AddPart()
        {
            Console.Clear();
            Console.WriteLine("Добавить партию.\n");
            try
            {
                Console.WriteLine("ID товара:");
                int IdProduct = int.Parse(Console.ReadLine());

                Console.WriteLine("ID склада:");
                int IdStock = int.Parse(Console.ReadLine());

                Console.WriteLine("Количество:");
                int quantity = int.Parse(Console.ReadLine());

                Part part = new Part(IdProduct, IdStock, quantity);
                new PartService().AddPart(part);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Thread.Sleep(3000);
            MainMenuController.WriteMenu(MainMenuController.options, MainMenuController.options.First());

        }

        public static void DeletePart()
        {
            Console.Clear();
            Console.WriteLine("Удалить партию.\n");

            try
            {
                Console.WriteLine("Введите уникальный номер партии:");
                int idPart = int.Parse(Console.ReadLine());

                new PartService().DeletePart(idPart);
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
