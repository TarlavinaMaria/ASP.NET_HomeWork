using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBooks.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BookService _bookService;

        public IndexModel()
        {
            _bookService = new BookService();
        }
        public List<Book> Books { get; set; }// список книг

        //Поиск
        //По умолчанию, [BindProperty] работает только с POST-запросами.
        //Однако, если вам нужно, чтобы свойства модели заполнялись данными из GET-запросов (например, из URL-параметров),
        //вы можете использовать параметр SupportsGet = true.
        [BindProperty(SupportsGet = true)]
        public string SearchTitle { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchAuthor { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchGenre { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchPublisher { get; set; }

        // для года ставим int? - позволяет явно указать, что это свойство может быть не заполнено. А так же для проверки. 
        [BindProperty(SupportsGet = true)]
        public int? SearchYear { get; set; }

        public void OnGet()
        {
            var allBooks = _bookService.GetAllBooks();
            //Поиск
            //Метод AsQueryable преобразует список. IQueryable позволяет строить запросы LINQ, которые могут быть выполнены позже.
            /* Принцип работы
            Каждая строка применяет фильтр к списку книг, если соответствующий критерий поиска задан.
            WhereIf: Это метод расширения, который принимает условие и предикат. Если условие истинно, предикат добавляется к запросу.
            !string.IsNullOrEmpty(_): Проверяет, что запрос не является пустой строкой или null.
            b => b.Title.Contains(_): Предикат, который фильтрует книги, у которых название содержит значение _.
             */
            Books = allBooks.AsQueryable()
           .WhereIf(!string.IsNullOrEmpty(SearchTitle), b => b.Title.Contains(SearchTitle))
           .WhereIf(!string.IsNullOrEmpty(SearchAuthor), b => b.Author.Contains(SearchAuthor))
           .WhereIf(!string.IsNullOrEmpty(SearchGenre), b => b.Genre.Contains(SearchGenre))
           .WhereIf(!string.IsNullOrEmpty(SearchPublisher), b => b.Publisher.Contains(SearchPublisher))
           .WhereIf(SearchYear.HasValue, b => b.YearPublished == SearchYear)
           .ToList();
        }

    }
    public static class QueryableExtensions // класс для поиска
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, System.Linq.Expressions.Expression<System.Func<T, bool>> predicate)
        {
            //Этот метод расширения позволяет условно добавлять фильтры к запросу IQueryable<T>.
            //Если условие (condition) истинно, метод добавляет предикат (predicate) к запросу.
            //Если условие ложно, метод возвращает исходный запрос без изменений.
            if (condition)
                return query.Where(predicate);
            else
                return query;
        }
    }
}

