using EmployeePortal.Models;
using EmployeePortal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeePortal.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public DeleteModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
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

        public IActionResult OnPost(int id)
        {
            _employeeService.Delete(id);

            TempData["SuccessMessage"] = "Employee was successfully deleted.";
            return RedirectToPage("./Index");
        }
    }
}