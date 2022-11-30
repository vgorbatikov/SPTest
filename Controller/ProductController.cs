using SPTest.Model;
using SPTest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SPTest.Controller
{
    class ProductController
    {
        public static void GetProductList()
        {
            Console.Clear();
            Console.WriteLine("Список товарных наименований.\n");

            List<Product> products = new ProductService().getProductList();
            foreach (Product product in products)
            {
                Console.WriteLine("ID: " + product.IdProduct);
                Console.WriteLine("Наименование: " + product.Name);
            }

            Thread.Sleep(3000);
            MainMenuController.WriteMenu(MainMenuController.options, MainMenuController.options.First());

        }

        public static void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("Добавить товар.\n");

            try
            {
                Console.WriteLine("Введите наименование товара:");
                String productName = Console.ReadLine();

                Product product = new Product(productName);
                new ProductService().AddProduct(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Thread.Sleep(3000);
            MainMenuController.WriteMenu(MainMenuController.options, MainMenuController.options.First());

        }

        public static void DeleteProduct()
        {
            Console.Clear();
            Console.WriteLine("Удалить товар.\n");

            try
            {
                Console.WriteLine("Введите уникальный номер товара:");
                int idProduct = int.Parse(Console.ReadLine());

                new ProductService().DeleteProduct(idProduct);
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
