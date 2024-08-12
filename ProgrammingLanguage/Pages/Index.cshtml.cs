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

        public IActionResult OnPostDelete(string name) // Вызывается при POST-запросе на удаление языка
        {
            var languages = _repository.GetLanguages();// Получает текущий список языков из репозитория
            var languageToRemove = languages.FirstOrDefault(l => l.Name == name);// Ищет язык с заданным именем в списке
            if (languageToRemove != null)
            {
                languages.Remove(languageToRemove);
                _repository.SaveLanguages(languages);
            }
            return RedirectToPage(); // Перенаправляет пользователя обратно на текущую страницу, чтобы обновить отображение списка языков
        }
    }
}
