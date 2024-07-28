using System.ComponentModel.DataAnnotations;
namespace LibraryBooks
{
    public class Book
    {
        [Required(ErrorMessage = "Название книги обязательно")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ФИО автора обязательно")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Жанр обязателен")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Издательство обязательно")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Год издания обязателен")]
        [Range(1, int.MaxValue, ErrorMessage = "Год издания должен быть положительным числом")]
        public int YearPublished { get; set; }
    }
}
