using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace RazorPagesDemo.Pages
{
    public class Employee
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class EmployeeModel : PageModel
    {
        public List<Employee> EmployeeList { get; set; }
        public EmployeeModel(List<Employee> ListOfEmployee) 
        {
            EmployeeList = ListOfEmployee;
            EmployeeList.Add(new Employee()
            {
                id = 1,
                FirstName = "Иван",
                LastName = "Кучеренко"
            });
            EmployeeList.Add(new Employee()
            {
                id = 2,
                FirstName = "Владимир",
                LastName = "Пут"
            });
            EmployeeList.Add(new Employee()
            {
                id = 3,
                FirstName = "Магомед",
                LastName = "Сидорчук"
            });

        }

        //[BindProperties(SupportsGet = true)]
        public int Id{ get; set; }
        public void OnGet(int Id) 
            { 
                if(Id == 0)
                this.Id = 1;
            }
    }
}
