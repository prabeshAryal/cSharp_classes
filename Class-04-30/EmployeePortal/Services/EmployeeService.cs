using EmployeePortal.Models;
using EmployeePortal.Repositories;

namespace EmployeePortal.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employee? GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public void Add(Employee employee)
        {
            _employeeRepository.Add(employee);
        }

        public void Update(Employee employee)
        {
            _employeeRepository.Update(employee);
        }

        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
        }
    }
}