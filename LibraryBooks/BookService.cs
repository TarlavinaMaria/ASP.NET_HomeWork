using System.Collections.Generic;
using System.Linq;

namespace LibraryBooks
{
    public class BookService
    {
        private static List<Book> allBooks = new List<Book>
        {
                new Book { Title = "1984", Author = "Джордж Оруэлл", Genre = "Научная фантастика", Publisher = "Secker & Warburg", YearPublished = 1949 },
                new Book { Title = "Убить пересмешника", Author = "Харпер Ли", Genre = " Роман", Publisher = "J. B. Lippincott & Co.", YearPublished = 1960 },
                new Book { Title = "Великий Гэтсби", Author = "Фрэнсис Скотт Фицджеральд", Genre = "Роман", Publisher = "Charles Scribner's Sons", YearPublished = 1925 },
                new Book { Title = "Сто лет одиночества", Author = "Габриэль Гарсиа Маркес", Genre = " Магический реализм", Publisher = "Editorial Sudamericana", YearPublished = 1967 },
                new Book { Title = "Дом, в котором...", Author = "Мариам Петросян", Genre = "Мистика", Publisher = "Издательство Эксмо", YearPublished = 2012 }
        };
        public List<Book> GetAllBooks()
        {
            return allBooks;
        }
        public Book GetBookByTitle(string title)
        {
            return allBooks.FirstOrDefault(b => b.Title == title);
        }

        public void AddBook(Book book)
        {
            allBooks.Add(book);
        }
        public void DeleteBook(string title)
        {
            var bookToRemove = allBooks.FirstOrDefault(b => b.Title == title);
            if (bookToRemove != null)
            {
                allBooks.Remove(bookToRemove);
            }
        }

        public void UpdateBook(Book book)
        {
            var existingBook = allBooks.FirstOrDefault(b => b.Title == book.Title);
            if (existingBook != null)
            {
                existingBook.Author = book.Author;
                existingBook.Genre = book.Genre;
                existingBook.Publisher = book.Publisher;
                existingBook.YearPublished = book.YearPublished;
            }
        }
    }
}
