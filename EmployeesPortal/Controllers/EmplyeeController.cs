using EmployeePortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace EmployeePortal.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }
        [HttpGet]
        public async Task<IActionResult> List(
            [FromQuery] string SearchTerm,
            [FromQuery] string SelectedDepartament,
            [FromQuery] string SelectedType,
            [FromQuery] int PageNumber = 1,
            [FromQuery] int PageSize = 5
            )
        {
            var (employees, totalCount) = await
                    _employeeService.GetEmployees(SearchTerm, SelectedDepartament, SelectedType, PageNumber, PageSize);

            var viewModel = new EmployeeListViewModel
            {
                Employees = employees,
                PageNumber = PageNumber,
                PageSize = PageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / PageSize),
                SearchTerm = SearchTerm,
                SelectedDepartment = SelectedDepartament,
                SelectedType = SelectedType
            };

            GetSelectLists();
            ViewBag.PageSizeOptioons = new SelectList(new List<int> { 3, 5, 10, 15, 20, 25 },
                PageSize);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            GetSelectLists();
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.CreateEmployee(employee);
                return RedirectToAction("Success", new { id = employee.id });
            }
            GetSelectLists();
            return View(employee);
        }

        public IActionResult Success([FromRoute] int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null) { return NotFound(); }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null) { return NotFound(); }
            return View(employee);

        }
        [HttpPost]
        IActionResult Update([FromForm] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(employee);

                TempData["Сообщение"] = $"Сотрудник номер {employee.id} и с именем {employee.FullName} обновлен.";
                return RedirectToAction("List");
            }
            GetSelectList();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null) { return NotFound(); }
            return View(employee);


        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null) { return NotFound(); }
            _employeeService.DeleteEmployee(id);

            TempData["Сообщение"] = $"Сотрудник номер {employee.id} и с именем {employee.FullName} удален.";
            return RedirectToAction("List");
        }
        [HttpGet]
        public JsonResult GetPositions(Department department)
        {
            var positions = new Dictionary<Department, List<string>>
            {
                { Department.IT, new List<string>{"Разаработка ПО", "Системное администрирование", "Сетевое администрирование" }},

        {
                Department.HR, new List<string> {"Специалист по кадрам", "Менеджер по кадрам", "Координатор" }},

{
    Department.Sales, new List<string> { "Менеджер продаж", "Специалист по продажам", "Начальник отдела" }},
            {
                Department.Admin, new List<string> { "Офис-менеджер", "Ассистент", "Служащий ресепшна" }}
                };

            var
            return Json(result);

        }
        private void Ge
    }
}














