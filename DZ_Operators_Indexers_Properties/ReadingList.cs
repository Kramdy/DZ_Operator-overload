using System;

namespace DZ_Module5_Operators_Indexers_Properties
{
    // Задание 3
    // Создайте приложение «Список книг для прочтения». Приложение должно позволять
    // добавлять книги в список, удалять книги из списка, проверять есть ли книга в
    // списке, и т. д. Используйте механизм свойств, перегрузки операторов, индексаторов.
    internal class Book
    {
        public string Title { get; set; }
        public Book(string title) { Title = title; }
    }

    internal class ReadingList
    {
        private Book[] books;
        public int Count { get; private set; }
        public ReadingList() { books = new Book[0]; Count = 0; }
        public Book this[int index]
        {
            get { if (index < 0 || index >= Count) throw new IndexOutOfRangeException(); return books[index]; }
            set { if (index < 0 || index >= Count) throw new IndexOutOfRangeException(); books[index] = value; }
        }
        public void Add(Book book)
        {
            if (book == null || book.Title == null || book.Title == "") return;
            Array.Resize(ref books, Count + 1); books[Count] = book; Count++;
        }
        public void Remove(Book book)
        {
            for (int i = 0; i < Count; i++)
                if (books[i].Title.ToLower() == book.Title.ToLower())
                {
                    for (int j = i; j < Count - 1; j++) books[j] = books[j + 1];
                    Array.Resize(ref books, Count - 1); Count--; return;
                }
            Console.WriteLine("Книга не найдена.");
        }
        public bool Contains(string title)
        {
            for (int i = 0; i < Count; i++) if (books[i].Title.ToLower() == title.ToLower()) return true;
            return false;
        }
        public void Display()
        {
            if (Count == 0) { Console.WriteLine("Список пуст."); return; }
            for (int i = 0; i < Count; i++) Console.WriteLine((i + 1) + ". " + this[i].Title);
        }
        public static ReadingList operator +(ReadingList list, Book book) { list.Add(book); return list; }
        public static ReadingList operator -(ReadingList list, Book book) { list.Remove(book); return list; }
    }
}
