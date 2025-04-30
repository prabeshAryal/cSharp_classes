using EmployeePortal.Models;
using EmployeePortal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeePortal.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public EditModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            Employee = employee;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _employeeService.Update(Employee);

            TempData["SuccessMessage"] = $"Employee {Employee.FullName} was successfully updated.";
            return RedirectToPage("./Index");
        }
    }
}