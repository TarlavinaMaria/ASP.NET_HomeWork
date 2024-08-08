using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProgrammingLanguage.Data;
using ProgrammingLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingLanguage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LanguageRepository _repository;

        public List<Language> Languages { get; set; }

        public IndexModel(LanguageRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
            Languages = _repository.GetLanguages();
        }

        public IActionResult OnPostDelete(string name)
        {
            var languages = _repository.GetLanguages();
            var languageToRemove = languages.FirstOrDefault(l => l.Name == name);
            if (languageToRemove != null)
            {
                languages.Remove(languageToRemove);
                _repository.SaveLanguages(languages);
            }
            return RedirectToPage();
        }
    }
}
