using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryBooks.Pages
{
    public class CreateModel : PageModel
    {
        private readonly BookService _bookService;

        public CreateModel()
        {
            _bookService = new BookService();
        }

        [BindProperty]
        public Book Book { get; set; }
        public IActionResult OnGet()
        {
            // Инициализация Book, если необходимо
            Book = new Book();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _bookService.AddBook(Book);
            return RedirectToPage("/Index");
        }
    }
}
