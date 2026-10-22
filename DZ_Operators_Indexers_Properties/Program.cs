using System;
using System.Text;

namespace DZ_Module5_Operators_Indexers_Properties
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1 — журнал: свойства и операторы");
                Console.WriteLine("2 — магазин: свойства и операторы");
                Console.WriteLine("3 — список книг для прочтения");
                Console.WriteLine("0 — выход");
                Console.Write("Выберите задание: ");
                switch (Console.ReadLine())
                {
                    case "1": WorkWithMagazine(); break;
                    case "2": WorkWithShop(); break;
                    case "3": WorkWithReadingList(); break;
                    case "0": return;
                    default: Console.WriteLine("Введите число от 0 до 3."); break;
                }
            }
        }

        private static void WorkWithMagazine()
        {
            try
            {
                Magazine magazine = new Magazine();
                magazine.Input();
                Console.Write("На сколько увеличить количество сотрудников: ");
                magazine = magazine + Convert.ToInt32(Console.ReadLine());
                magazine.Display();
            }
            catch (Exception) { Console.WriteLine("Введите корректные данные."); }
        }

        private static void WorkWithShop()
        {
            try
            {
                Shop shop = new Shop();
                shop.Input();
                Console.Write("На сколько увеличить площадь: ");
                shop = shop + Convert.ToDouble(Console.ReadLine());
                shop.Display();
            }
            catch (Exception) { Console.WriteLine("Введите корректные данные."); }
        }

        private static void WorkWithReadingList()
        {
            ReadingList books = new ReadingList();
            while (true)
            {
                Console.WriteLine("\n1 — добавить книгу; 2 — удалить книгу; 3 — проверить книгу; 4 — показать список; 0 — назад");
                Console.Write("Выберите действие: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Название книги: ");
                        books = books + new Book(Console.ReadLine());
                        break;
                    case "2":
                        Console.Write("Название книги для удаления: ");
                        books = books - new Book(Console.ReadLine());
                        break;
                    case "3":
                        Console.Write("Название книги для поиска: ");
                        Console.WriteLine(books.Contains(Console.ReadLine()) ? "Книга есть в списке." : "Книги нет в списке.");
                        break;
                    case "4": books.Display(); break;
                    case "0": return;
                    default: Console.WriteLine("Введите число от 0 до 4."); break;
                }
            }
        }
    }
}
