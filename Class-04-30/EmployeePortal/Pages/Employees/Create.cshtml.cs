using EmployeePortal.Models;
using EmployeePortal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeePortal.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public CreateModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
        public Employee Employee { get; set; } = new Employee();

        public IActionResult OnGet()
        {
            // Initialize default values if needed
            Employee.HireDate = DateTime.Today;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _employeeService.Add(Employee);

            TempData["SuccessMessage"] = $"Employee {Employee.FullName} was successfully created.";
            return RedirectToPage("./Index");
        }
    }
}