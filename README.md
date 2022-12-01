# SPTest
Результат выполнения следующей задачи.
-------------------------------------------------------------------------------------------------------------------------
Написать консольное приложение(Console App) для аптечной компании.

Список товарных наименований (минимальный набор полей: id товара, наименование):
1. Создать товар
2. Удалить товар (удалить товар и все партии во всех аптеках, связанные с этим товаром)

Список аптек (минимальный набор полей: id аптеки, наименование, адресс, телефон):
1. Создать аптеку
2. Удалить аптеку (удалить аптеку, все склады аптеки и партии в складах)

Список складов (минимальный набор полей: id склада, id аптеки, наименование):
1. Создать склад
2. Удалить склад (удалить склад, все данные о партиях в этом складе)

Список партий (минимальный набор полей: id партии, id товара, id склада, количество в партии):
1. Создать партию
2. Удалить партию


Так же нужно добавить следующую команду:
1. Вывести на экран весь список товаров и его количество в выбранной аптеке (количество товара во всех складах аптеки)

Код написать на C# и SQL(без использования EF и подобных). Так же не использовать какие-либо сторонние nuget пакеты.

Что использовал.
----------------

1. Олдскульный .Net Framework версии 4.7.2
2. MS SQL Server 2019 Express

Как запустить
-------------
1. Создать БД (скрипт в \sql\db_init.sql)
2. Настроить connectionString (в App.config параметр connectionString - сейчас настроен на локальную БД)
3. Собрать проект

В проекте
---------
1. Продемонстрировал навыки работы с транзакциями
2. Проект получился масштабируемым (логику для визуализации, работы с БД и модели разнёс по отдельным пакетам)
3. Получилась почти приличная интерактивность (как для консольного приложения)

Для того, чтобы проект запустился в реальных боевых условиях (он пока тестовый), необходимо:
--------------------------------------------------------------------------------------------

1. Переписать его под .Net Core (тогда можно будет реализовать асинхронные процессы для работы с БД)
2. Добавить нормальный логгер (nuget пакееты я сейчас не использую)
3. Покрыть код unit тестами (как минимум - логику для взаимодействия с БД - это в будущем очень сильно упрощает жизнь при поддержке проекта)
4. Консоль заменить на Windows Forms а лучше на Web Forms и дописать CRUD (по заданию я реализовал добавление и удаление и по своей инициативе добавил самый простенький вывод списка, но в реальной жизни его использовать очень неудобно).

Тесты по SQL
------------
Выложил в отдельную папку SQLTests.


