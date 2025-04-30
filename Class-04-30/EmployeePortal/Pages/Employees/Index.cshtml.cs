using EmployeePortal.Models;
using EmployeePortal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeePortal.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public IndexModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public void OnGet()
        {
            Employees = _employeeService.GetAll();
        }
    }
}