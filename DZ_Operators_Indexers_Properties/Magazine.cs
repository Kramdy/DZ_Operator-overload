using System;

namespace DZ_Module5_Operators_Indexers_Properties
{
    // Задание 1
    // Ранее в одном из практических заданий вы создавали класс «Журнал». Добавьте
    // к уже созданному классу информацию о количестве сотрудников. Выполните перегрузку
    // + (для увеличения количества сотрудников на указанную величину), — (для уменьшения
    // количества сотрудников на указанную величину), == (проверка на равенство количества
    // сотрудников), < и > (проверка на меньше или больше количества сотрудников), != и Equals.
    // Используйте механизм свойств для полей класса.
    internal class Magazine
    {
        public string Name { get; set; }
        public int FoundationYear { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int EmployeesCount { get; set; }

        public void Input()
        {
            Console.Write("Название журнала: "); Name = Console.ReadLine();
            Console.Write("Год основания: "); FoundationYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Описание: "); Description = Console.ReadLine();
            Console.Write("Телефон: "); Phone = Console.ReadLine();
            Console.Write("E-mail: "); Email = Console.ReadLine();
            Console.Write("Количество сотрудников: "); EmployeesCount = Convert.ToInt32(Console.ReadLine());
            if (EmployeesCount < 0) throw new Exception();
        }
        public void Display() { Console.WriteLine("\nЖурнал: " + Name + "\nГод: " + FoundationYear + "\nОписание: " + Description + "\nТелефон: " + Phone + "\nE-mail: " + Email + "\nСотрудников: " + EmployeesCount); }
        public static Magazine operator +(Magazine magazine, int count) { magazine.EmployeesCount += count; return magazine; }
        public static Magazine operator -(Magazine magazine, int count) { magazine.EmployeesCount -= count; if (magazine.EmployeesCount < 0) magazine.EmployeesCount = 0; return magazine; }
        public static bool operator ==(Magazine first, Magazine second)
        {
            if (object.ReferenceEquals(first, second)) return true;
            if (object.ReferenceEquals(first, null) || object.ReferenceEquals(second, null)) return false;
            return first.EmployeesCount == second.EmployeesCount;
        }
        public static bool operator !=(Magazine first, Magazine second) { return !(first == second); }
        public static bool operator <(Magazine first, Magazine second) { return first.EmployeesCount < second.EmployeesCount; }
        public static bool operator >(Magazine first, Magazine second) { return first.EmployeesCount > second.EmployeesCount; }
        public override bool Equals(object obj) { Magazine magazine = obj as Magazine; return !object.ReferenceEquals(magazine, null) && EmployeesCount == magazine.EmployeesCount; }
        public override int GetHashCode() { return EmployeesCount.GetHashCode(); }
    }
}
