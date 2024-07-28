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
        public List<Book> Books { get; set; }

        public void OnGet()
        {
            Books = new List<Book>
            {
                new Book { Title = "1984", Author = "Джордж Оруэлл", Genre = "Научная фантастика", Publisher = "Secker & Warburg", YearPublished = 1949 },
                new Book { Title = "Убить пересмешника", Author = "Харпер Ли", Genre = " Роман", Publisher = "J. B. Lippincott & Co.", YearPublished = 1960 },
                new Book { Title = "Великий Гэтсби", Author = "Фрэнсис Скотт Фицджеральд", Genre = "Роман", Publisher = "Charles Scribner's Sons", YearPublished = 1925 },
                new Book { Title = "Сто лет одиночества", Author = "Габриэль Гарсиа Маркес", Genre = " Магический реализм", Publisher = "Editorial Sudamericana", YearPublished = 1967 },
                new Book { Title = "Дом, в котором...", Author = "Мариам Петросян", Genre = "Мистика", Publisher = "Издательство Эксмо", YearPublished = 2012 }
            };
        }
    }
}
