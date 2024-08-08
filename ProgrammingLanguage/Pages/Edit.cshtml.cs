using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgrammingLanguage.Data;
using ProgrammingLanguage.Models;
using System.Linq;

namespace ProgrammingLanguage.Pages
{
    public class EditModel : PageModel
    {
        private readonly LanguageRepository _repository;

        [BindProperty]
        public Language Language { get; set; }

        public EditModel(LanguageRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var languages = _repository.GetLanguages();
            Language = languages.FirstOrDefault(l => l.Name == name);

            if (Language == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var languages = _repository.GetLanguages();
            var existingLanguage = languages.FirstOrDefault(l => l.Name == Language.Name);

            if (existingLanguage != null)
            {
                existingLanguage.Type = Language.Type;
                existingLanguage.Rating = Language.Rating;
                _repository.SaveLanguages(languages);
            }

            return RedirectToPage("./Index");
        }
    }
}

