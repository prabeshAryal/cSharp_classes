using EmployeePortal.Models;
using EmployeePortal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeePortal.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public DetailsModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public Employee? Employee { get; set; }

        public IActionResult OnGet(int id)
        {
            Employee = _employeeService.GetById(id);
            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}