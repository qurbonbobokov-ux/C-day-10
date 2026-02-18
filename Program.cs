using System;
using MainApp.Domain.Models;
using MainApp.Infrastructure.Services;

class Program
{
    static void Main()
    {
        DepartmentService departmentService = new DepartmentService();
        EmployeeService employeeService = new EmployeeService();

        Department it = new Department
        {
            Name = "IT",
            Description = "Information Technology"
        };

        Employee emp1 = new Employee
        {
            Firstname = "Ali",
            Lastname = "Karimov",
            BirthDate = new DateTime(1999, 5, 12),
            Salary = 2500,
            Department = it
        };

        it.Manager = emp1;

        departmentService.AddDepartment(it);
        employeeService.AddEmployee(emp1);

        Console.WriteLine("Employees count: " + employeeService.CountEmployees());
        Console.WriteLine("Departments count: " + departmentService.CountDepartments());
    }
}

namespace MainApp.Infrastructure.Services
{
    public class DepartmentService
    {
        private readonly List<Department> departments = new List<Department>();

        public void AddDepartment(Department department)
        {
            if (department == null) new ArgumentNullException();
            departments.Add(department);
        }

        public int CountDepartments()
        {
            return departments.Count;
        }
    }

    public class EmployeeService
    {
        private  List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            if (employee == null) new ArgumentNullException();
            employees.Add(employee);
        }

        public int CountEmployees()
        {
            return employees.Count;
        }
    }
}
