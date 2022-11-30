using System;
using SPTest.Controller;

namespace SPTest
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Движок главного меню. По хорошему, его тоже можно перенести в MainMenuController,
            // но и тут тоже неплохое для него место, пока проект маленький

            // Строю главное меню
            MainMenuController.BuildMainMenu();

            // Устанавливаю индекс по умолчанию
            int index = 0;

            // Отображаю главное меню
            MainMenuController.WriteMenu(MainMenuController.options, MainMenuController.options[index]);

            // Контейнер для кнопки управления меню (вверх, вниз, ввод)
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                // Обработка реакции Стралка вниз
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < MainMenuController.options.Count)
                    {
                        index++;
                        MainMenuController.WriteMenu(MainMenuController.options, MainMenuController.options[index]);
                    }
                }
                // Обработка реакции Стрелка вверх
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        MainMenuController.WriteMenu(MainMenuController.options, MainMenuController.options[index]);
                    }
                }
                // Обработка реакции на Ввод
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    MainMenuController.options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();

        }
    }
}
