using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SPTest.Model;
using SPTest.Service;

namespace SPTest.Controller
{
    class PharmacyController
    {
        public static void GetPharmacyList()
        {
            Console.Clear();
            Console.WriteLine("Список аптек.\n");

            List<Pharmacy> phList = new PharmacyService().getPharmacyList();
            foreach (Pharmacy pharmacy in phList)
            {
                Console.WriteLine("ID: " + pharmacy.IdPharmacy);
                Console.WriteLine("Название: " + pharmacy.Name);
                Console.WriteLine("Адрес: " + pharmacy.Address);
                Console.WriteLine("Телефон: " + pharmacy.Phone);
            }

            Thread.Sleep(3000);
            MainMenuController.WriteMenu(MainMenuController.options, MainMenuController.options.First());

        }

        public static void AddPharmacy()
        {
            Console.Clear();
            Console.WriteLine("Добавить аптеку.\n");

            try
            {
                Console.WriteLine("Название:");
                String pharmacyName = Console.ReadLine();

                Console.WriteLine("Адрес:");
                String pharmacyAddress = Console.ReadLine();

                Console.WriteLine("Телефон:");
                String pharmacyPhone = Console.ReadLine();

                Pharmacy pharmacy = new Pharmacy(pharmacyName, pharmacyAddress, pharmacyPhone);
                new PharmacyService().AddPharmacy(pharmacy);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

            Thread.Sleep(3000);
            MainMenuController.WriteMenu(MainMenuController.options, MainMenuController.options.First());

        }

        public static void DeletePharmacy()
        {
            Console.Clear();
            Console.WriteLine("Удалить аптеку.\n");

            try
            {
                Console.WriteLine("Введите уникальный номер аптеки:");
                int idPharmacy = int.Parse(Console.ReadLine());

                new PharmacyService().DeletePharmacy(idPharmacy);
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
