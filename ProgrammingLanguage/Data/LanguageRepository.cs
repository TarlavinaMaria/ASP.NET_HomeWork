using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ProgrammingLanguage.Models;

namespace ProgrammingLanguage.Data
{
    public class LanguageRepository
    {
        private const string FilePath = "languages.json";

        public List<Language> GetLanguages()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Language>();
            }

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Language>>(json);
        }

        public void SaveLanguages(List<Language> languages)
        {
            var json = JsonSerializer.Serialize(languages);
            File.WriteAllText(FilePath, json);
        }
    }
}
