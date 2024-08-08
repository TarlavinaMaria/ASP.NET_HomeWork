using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgrammingLanguage.Data;
using ProgrammingLanguage.Models;

namespace ProgrammingLanguage.Pages
{
    public class CreateModel : PageModel
    {
        private readonly LanguageRepository _repository;

        [BindProperty]
        public Language Language { get; set; }

        public CreateModel(LanguageRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var languages = _repository.GetLanguages();
            languages.Add(Language);
            _repository.SaveLanguages(languages);

            return RedirectToPage("./Index");
        }
    }
}

