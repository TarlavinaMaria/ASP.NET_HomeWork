using EmployeesPortal.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeePortal.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ФИО обязательно")]
        [StringLength(100, ErrorMessage = "ФИО не может быть длиннее 100 символов")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Неверный формат Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Должность обязательна")]
        [StringLength(50, ErrorMessage = "Должность не может быть длиннее 50 символов")]
        [Display(Name = "Должность")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Отдел обязателен")]
        [Display(Name = "Отдел")]
        public Department? Department { get; set; }

        [Required(ErrorMessage = "Дата приема обязательна")]
        [Display(Name = "Дата приема")]
        [DataType(DataType.Date, ErrorMessage = "Неверный формат даты")]
        public DateTime? HireDate { get; set; }

        [Required(ErrorMessage = "Дата рождения обязательна")]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date, ErrorMessage = "Неверный формат даты")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Тип сотрудника обязателен")]
        [Display(Name = "Тип сотрудника")]
        public EmployeeType? Type { get; set; }

        [Required(ErrorMessage = "Пол обязателен")]
        [StringLength(6, ErrorMessage = "Пол должен быть 'Мужской', 'Женский' или 'Другой'")]
        [Display(Name = "Пол")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Зарплата обязательна")]
        [Range(0, double.MaxValue, ErrorMessage = "Зарплата должна быть положительным числом")]
        [DataType(DataType.Currency)]
        [Display(Name = "Зарплата")]
        public decimal? Salary { get; set; }
    }
}