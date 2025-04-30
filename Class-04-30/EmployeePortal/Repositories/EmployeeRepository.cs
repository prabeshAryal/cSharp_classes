using EmployeePortal.Models;

namespace EmployeePortal.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        // In-memory collection to store employees
        private readonly List<Employee> _employees;
        private int _nextId = 1;

        public EmployeeRepository()
        {
            // Initialize with some sample data
            _employees = new List<Employee>
            {
                new Employee
                {
                    Id = _nextId++,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "555-123-4567",
                    Department = "IT",
                    HireDate = new DateTime(2021, 5, 15)
                },
                new Employee
                {
                    Id = _nextId++,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "555-987-6543",
                    Department = "HR",
                    HireDate = new DateTime(2022, 2, 10)
                },
                new Employee
                {
                    Id = _nextId++,
                    FirstName = "Michael",
                    LastName = "Johnson",
                    Email = "michael.johnson@example.com",
                    PhoneNumber = "555-456-7890",
                    Department = "Finance",
                    HireDate = new DateTime(2020, 11, 3)
                }
            };
        }

        public List<Employee> GetAll()
        {
            return _employees.OrderBy(e => e.LastName).ToList();
        }

        public Employee? GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Employee employee)
        {
            // Assign a new ID
            employee.Id = _nextId++;
            _employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            var existingEmployee = GetById(employee.Id);
            if (existingEmployee != null)
            {
                // Update all properties
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Email = employee.Email;
                existingEmployee.PhoneNumber = employee.PhoneNumber;
                existingEmployee.Department = employee.Department;
                existingEmployee.HireDate = employee.HireDate;
            }
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}