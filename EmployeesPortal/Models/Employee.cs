using System.ComponentModel.DataAnnotations;
namespace EmployeesPortal.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Неверное имя.")]
        [StringLength(100, ErrorMessage = "Полное имя не должно содержать более 100 символов.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Адрес почты не верный.")]
        [EmailAddress(ErrorMessage = "Проверте адрес электронной почты.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ошибка в наименовании должности.")]
        [StringLength(50, ErrorMessage = "В наименовании должности не должно быть больше 50 символов.")]
        [Display(Name = "Post")]
        public string Position { get; set; }
        ///

        [Required(ErrorMessage = "Ошибка в наименование подразделения.")]
        public Departament? Departament { get; set; }


        [Required(ErrorMessage = "Неверная дата приема на работу.")]
        [Display(Name = "Data")]
        [DataType(DataType.Date, ErrorMessage = "Неверный формат даты")]
        public DateTime? HireDate { get; set; }
        ///

        [Required(ErrorMessage = "Неверная дата рождения.")]
        [Display(Name = "DataBirth")]
        [DataType(DataType.Date, ErrorMessage = "Неверный формат даты")]
        public DateTime? DateOfBirht { get; set; }
        ///

        [Required(ErrorMessage = "Неверный тип занятости.")]
        [Display(Name = "Type")]
        public EmployeeType? Type { get; set; }

        [Required(ErrorMessage = "Неверный пол.")]
        [StringLength(3, ErrorMessage = "Укажите МУЖ или ЖЕН")]
        public string Pol { get; set; }

        [Required(ErrorMessage = "Ощибка в сумме заработка")]
        [Range(0, double.MaxValue, ErrorMessage = "ЗП не может быть отрицательной")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
    }
}
