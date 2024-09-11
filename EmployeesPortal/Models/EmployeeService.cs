namespace EmployeesPortal.Models
{
    public class EmployeeService
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                FullName = "Иван Петрович Черненко",
                Email = "Ivan@mail.ru",
                Position = "Программист",
                Departament = Departament.IT,
                HireDate = DateTime.Now.AddYears(-3),
                DateOfBirht = DateTime.Now.AddYears(-30),
                Type = EmployeeType.Parmanent,
                Pol = "МУЖ",
                Salary = 60000
            },
            new Employee
            {
                Id = 2,
                FullName = "Анна Сергеевна Иванова",
                Email = "Anna@mail.ru",
                Position = "Аналитик данных",
                Departament = Departament.DataScience,
                HireDate = DateTime.Now.AddYears(-2),
                DateOfBirht = DateTime.Now.AddYears(-28),
                Type = EmployeeType.Parmanent,
                Pol = "ЖЕН",
                Salary = 70000
            },
        new Employee
        {
            Id = 3,
            FullName = "Дмитрий Александрович Смирнов",
            Email = "Dmitry@mail.ru",
            Position = "Системный администратор",
            Departament = Departament.IT,
            HireDate = DateTime.Now.AddYears(-4),
            DateOfBirht = DateTime.Now.AddYears(-35),
            Type = EmployeeType.Parmanent,
            Pol = "МУЖ",
            Salary = 55000
        },
        new Employee
        {
            Id = 4,
            FullName = "Елена Викторовна Петрова",
            Email = "Elena@mail.ru",
            Position = "UX/UI Дизайнер",
            Departament = Departament.Design,
            HireDate = DateTime.Now.AddYears(-1),
            DateOfBirht = DateTime.Now.AddYears(-27),
            Type = EmployeeType.Parmanent,
            Pol = "ЖЕН",
            Salary = 65000
        },
        new Employee
        {
            Id = 5,
            FullName = "Сергей Иванович Михайлов",
            Email = "Sergey@mail.ru",
            Position = "Менеджер проекта",
            Departament = Departament.Management,
            HireDate = DateTime.Now.AddYears(-5),
            DateOfBirht = DateTime.Now.AddYears(-33),
            Type = EmployeeType.Parmanent,
            Pol = "МУЖ",
            Salary = 80000
        },
        new Employee
        {
            Id = 6,
            FullName = "Ольга Владимировна Соколова",
            Email = "Olga@mail.ru",
            Position = "Тестировщик",
            Departament = Departament.QA,
            HireDate = DateTime.Now.AddYears(-2),
            DateOfBirht = DateTime.Now.AddYears(-29),
            Type = EmployeeType.Parmanent,
            Pol = "ЖЕН",
            Salary = 58000
        },
        new Employee
        {
            Id = 7,
            FullName = "Алексей Петрович Новиков",
            Email = "Alexey@mail.ru",
            Position = "Бизнес-аналитик",
            Departament = Departament.BusinessAnalysis,
            HireDate = DateTime.Now.AddYears(-3),
            DateOfBirht = DateTime.Now.AddYears(-31),
            Type = EmployeeType.Parmanent,
            Pol = "МУЖ",
            Salary = 72000
        },
        new Employee
        {
            Id = 8,
            FullName = "Мария Александровна Федорова",
            Email = "Maria@mail.ru",
            Position = "Маркетолог",
            Departament = Departament.Marketing,
            HireDate = DateTime.Now.AddYears(-1),
            DateOfBirht = DateTime.Now.AddYears(-26),
            Type = EmployeeType.Parmanent,
            Pol = "ЖЕН",
            Salary = 63000
        },
        new Employee
        {
            Id = 9,
            FullName = "Игорь Викторович Козлов",
            Email = "Igor@mail.ru",
            Position = "DevOps Инженер",
            Departament = Departament.IT,
            HireDate = DateTime.Now.AddYears(-2),
            DateOfBirht = DateTime.Now.AddYears(-30),
            Type = EmployeeType.Parmanent,
            Pol = "МУЖ",
            Salary = 75000
        },
        new Employee
        {
            Id = 10,
            FullName = "Татьяна Сергеевна Морозова",
            Email = "Tatiana@mail.ru",
            Position = "HR-менеджер",
            Departament = Departament.HR,
            HireDate = DateTime.Now.AddYears(-3),
            DateOfBirht = DateTime.Now.AddYears(-32),
            Type = EmployeeType.Parmanent,
            Pol = "ЖЕН",
            Salary = 68000
        }
        };
    }
}
