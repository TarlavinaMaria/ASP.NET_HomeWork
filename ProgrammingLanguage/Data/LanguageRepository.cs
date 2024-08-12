using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ProgrammingLanguage.Models;

namespace ProgrammingLanguage.Data
{
    public class LanguageRepository
    {
        private const string FilePath = "languages.json";

        public List<Language> GetLanguages()// Чтение списка языков программирования из JSON-файла
        {
            if (!File.Exists(FilePath))// Проверяет, существует ли файл по указанному пути. Если нет, возвращается пустой список 
            {
                return new List<Language>();
            }

            var json = File.ReadAllText(FilePath);// Считывает все содержимое файла в виде строки
            return JsonSerializer.Deserialize<List<Language>>(json); // Преобразует JSON-строку в список объектов типа Language с использованием JsonSerializer.
        }

        public void SaveLanguages(List<Language> languages)// Запись списка языков программирования в JSON-файл
        {
            var json = JsonSerializer.Serialize(languages);// Преобразует список объектов Language в JSON-строку
            File.WriteAllText(FilePath, json);
        }
    }
}
