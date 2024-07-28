using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryBooks.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly BookService _bookService;

        public DeleteModel()
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
            _bookService.DeleteBook(id);
            return RedirectToPage("/Index");
        }
    }
}
