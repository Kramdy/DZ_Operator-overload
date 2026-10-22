using System;

namespace DZ_Module5_Operators_Indexers_Properties
{
    // Задание 2
    // Ранее в одном из практических заданий вы создавали класс «Магазин». Добавьте
    // к уже созданному классу информацию о площади магазина. Выполните перегрузку
    // + (для увеличения площади магазина на указанную величину), — (для уменьшения
    // площади магазина на указанную величину), == (проверка на равенство площадей
    // магазинов), < и > (проверка на меньше или больше площади магазина), != и Equals.
    // Используйте механизм свойств для полей класса.
    internal class Shop
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Area { get; set; }

        public void Input()
        {
            Console.Write("Название магазина: "); Name = Console.ReadLine();
            Console.Write("Адрес: "); Address = Console.ReadLine();
            Console.Write("Описание профиля: "); Description = Console.ReadLine();
            Console.Write("Телефон: "); Phone = Console.ReadLine();
            Console.Write("E-mail: "); Email = Console.ReadLine();
            Console.Write("Площадь: "); Area = Convert.ToDouble(Console.ReadLine());
            if (Area < 0) throw new Exception();
        }
        public void Display() { Console.WriteLine("\nМагазин: " + Name + "\nАдрес: " + Address + "\nОписание: " + Description + "\nТелефон: " + Phone + "\nE-mail: " + Email + "\nПлощадь: " + Area); }
        public static Shop operator +(Shop shop, double area) { shop.Area += area; return shop; }
        public static Shop operator -(Shop shop, double area) { shop.Area -= area; if (shop.Area < 0) shop.Area = 0; return shop; }
        public static bool operator ==(Shop first, Shop second)
        {
            if (object.ReferenceEquals(first, second)) return true;
            if (object.ReferenceEquals(first, null) || object.ReferenceEquals(second, null)) return false;
            return first.Area == second.Area;
        }
        public static bool operator !=(Shop first, Shop second) { return !(first == second); }
        public static bool operator <(Shop first, Shop second) { return first.Area < second.Area; }
        public static bool operator >(Shop first, Shop second) { return first.Area > second.Area; }
        public override bool Equals(object obj) { Shop shop = obj as Shop; return !object.ReferenceEquals(shop, null) && Area == shop.Area; }
        public override int GetHashCode() { return Area.GetHashCode(); }
    }
}
