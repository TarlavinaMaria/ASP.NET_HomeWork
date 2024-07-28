using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryBooks.Pages
{
    public class EditModel : PageModel
    {
        private readonly BookService _bookService;
        public EditModel()
        {
            _bookService = new BookService();
        }
        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet(string id)
        {
            Book = _bookService.GetBookByTitle(id);
            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost(string id)
        {
            var bookToUpdate = _bookService.GetBookByTitle(id);
            if (bookToUpdate == null)
            {
                return NotFound();
            }

            bookToUpdate.Title = Book.Title;
            bookToUpdate.Author = Book.Author;
            bookToUpdate.Genre = Book.Genre;
            bookToUpdate.Publisher = Book.Publisher;
            bookToUpdate.YearPublished = Book.YearPublished;

            _bookService.UpdateBook(bookToUpdate);

            return RedirectToPage("/Index");
        }
    }
}
