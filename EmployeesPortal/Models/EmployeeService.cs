using System.Xml.Linq;

namespace EmployeePortal.Models
{
    public class EmployeeService
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, FullName = "Иван Иванов", Email = "ivan@example.com", Position = "Разработчик ПО", Department = Department.IT, HireDate = DateTime.Now.AddYears(-3), DateOfBirth = DateTime.Now.AddYears(-30), Type = EmployeeType.Permanent, Gender = "Мужской", Salary = 60000 },
            new Employee { Id = 2, FullName = "Елена Смирнова", Email = "elena@example.com", Position = "Менеджер по персоналу", Department = Department.HR, HireDate = DateTime.Now.AddYears(-5), DateOfBirth = DateTime.Now.AddYears(-35), Type = EmployeeType.Permanent, Gender = "Женский", Salary = 80000 },
            new Employee { Id = 3, FullName = "Алексей Петров", Email = "alexey@example.com", Position = "Менеджер по продажам", Department = Department.Sales, HireDate = DateTime.Now.AddYears(-2), DateOfBirth = DateTime.Now.AddYears(-28), Type = EmployeeType.Contract, Gender ="Мужской", Salary = 50000 },
            new Employee { Id = 4, FullName = "Анна Козлова", Email = "anna@example.com", Position = "Администратор", Department = Department.Admin, HireDate = DateTime.Now.AddYears(-1), DateOfBirth = DateTime.Now.AddYears(-25), Type = EmployeeType.Temporary, Gender = "Женский", Salary = 40000 },
            new Employee { Id = 5, FullName = "Дмитрий Сидоров", Email = "dmitry@example.com", Position = "Сетевой инженер", Department = Department.IT, HireDate = DateTime.Now.AddYears(-4), DateOfBirth = DateTime.Now.AddYears(-32), Type = EmployeeType.Permanent, Gender = "Мужской", Salary = 70000 },
            new Employee { Id = 6, FullName = "Екатерина Иванова", Email = "ekaterina@example.com", Position = "Специалист по персоналу", Department = Department.HR, HireDate = DateTime.Now.AddYears(-6), DateOfBirth = DateTime.Now.AddYears(-34), Type = EmployeeType.Permanent, Gender = "Женский", Salary = 75000 },
            new Employee { Id = 7, FullName = "Сергей Михайлов", Email = "sergey@example.com", Position = "Менеджер по продажам", Department = Department.Sales, HireDate = DateTime.Now.AddYears(-3), DateOfBirth = DateTime.Now.AddYears(-31), Type = EmployeeType.Contract, Gender = "Мужской", Salary = 85000 },
            new Employee { Id = 8, FullName = "Ольга Васильева", Email = "olga@example.com", Position = "Менеджер офиса", Department = Department.Admin, HireDate = DateTime.Now.AddYears(-2), DateOfBirth = DateTime.Now.AddYears(-29), Type = EmployeeType.Permanent, Gender = "Женский", Salary = 65000 },
            new Employee { Id = 9, FullName = "Мария Федорова", Email = "maria@example.com", Position = "Системный администратор", Department = Department.IT, HireDate = DateTime.Now.AddYears(-1), DateOfBirth = DateTime.Now.AddYears(-26), Type = EmployeeType.Intern, Gender = "Женский", Salary = 30000 },
            new Employee { Id = 10, FullName = "Андрей Соколов", Email = "andrey@example.com", Position = "Координатор по подбору персонала", Department = Department.HR, HireDate = DateTime.Now.AddYears(-5), DateOfBirth = DateTime.Now.AddYears(-33), Type = EmployeeType.Temporary, Gender = "Другой", Salary = 55000 },
            new Employee { Id = 11, FullName = "София Лебедева", Email = "sofia@example.com", Position = "Менеджер по продажам", Department = Department.Sales, HireDate = DateTime.Now.AddYears(-2), DateOfBirth = DateTime.Now.AddYears(-27), Type = EmployeeType.Permanent, Gender = "Женский", Salary = 52000 },
            new Employee { Id = 12, FullName = "Лев Николаев", Email = "lev@example.com", Position = "Ресепшн", Department = Department.Admin, HireDate = DateTime.Now.AddYears(-1), DateOfBirth = DateTime.Now.AddYears(-24), Type = EmployeeType.Temporary, Gender = "Мужской", Salary = 38000 },
            new Employee { Id = 13, FullName = "Никита Морозов", Email = "nikita@example.com", Position = "Системный администратор", Department = Department.IT, HireDate = DateTime.Now.AddYears(-3), DateOfBirth = DateTime.Now.AddYears(-29), Type = EmployeeType.Permanent, Gender = "Мужской", Salary = 65000 },
            new Employee { Id = 14, FullName = "Ирина Белова", Email = "irina@example.com", Position = "Специалист по персоналу", Department = Department.HR, HireDate = DateTime.Now.AddYears(-4), DateOfBirth = DateTime.Now.AddYears(-30), Type = EmployeeType.Permanent, Gender = "Женский", Salary = 76000 },
            new Employee { Id = 15, FullName = "Алексей Орлов", Email = "alexey@example.com", Position = "Аккаунт-менеджер", Department = Department.Sales, HireDate = DateTime.Now.AddYears(-2), DateOfBirth = DateTime.Now.AddYears(-28), Type = EmployeeType.Contract, Gender = "Мужской", Salary = 62000 }
        };

        public async Task<(List<Employee> Employees, int TotalCount)> GetEmployees(
               string SearchTerm, // The search term used to filter employees by name
               string SelectedDepartment, // The selected department used to filter employees by department
               string SelectedType, // The selected employment type used to filter employees by employee type
               int PageNumber, // The current page number for pagination
               int PageSize) // The number of employees to display per page
        {
            // Convert the list of employees to an IQueryable to enable filtering and pagination
            // IQueryable allow dynamic querying with filtering and pagination.
            var filteredEmployees = employees.AsQueryable();

            // If a search term is provided, filter the employees by their full name, ignoring case
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                filteredEmployees = filteredEmployees.Where(p => p.FullName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase));
            }

            // If a department is selected, attempt to parse the department string to the Department enum
            if (!string.IsNullOrEmpty(SelectedDepartment))
            {
                if (Enum.TryParse(SelectedDepartment, out Department department))
                {
                    // Filter the employees by the selected department
                    filteredEmployees = filteredEmployees.Where(p => p.Department == department);
                }
            }

            // If an employment type is selected, attempt to parse the type string to the EmployeeType enum
            if (!string.IsNullOrEmpty(SelectedType))
            {
                if (Enum.TryParse(SelectedType, out EmployeeType type))
                {
                    // Filter the employees by the selected employment type
                    filteredEmployees = filteredEmployees.Where(p => p.Type == type);
                }
            }

            // Get the total count of employees after filtering, before pagination
            int totalCount = filteredEmployees.Count();

            // Apply pagination by skipping the previous pages and taking the current page's employees
            filteredEmployees = filteredEmployees.Skip((PageNumber - 1) * PageSize)
                               .Take(PageSize);

            // Return the filtered and paginated list of employees along with the total count
            return await Task.FromResult((filteredEmployees.ToList(), totalCount));
        }


        public Employee? GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public void CreateEmployee(Employee employee)
        {
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee = GetEmployeeById(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.FullName = employee.FullName;
                existingEmployee.Email = employee.Email;
                existingEmployee.Position = employee.Position;
                existingEmployee.Department = employee.Department;
                existingEmployee.HireDate = employee.HireDate;
                existingEmployee.DateOfBirth = employee.DateOfBirth;
                existingEmployee.Type = employee.Type;
                existingEmployee.Gender = employee.Gender;
                existingEmployee.Salary = employee.Salary;
            }
        }

        public void DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
        }
    }
}