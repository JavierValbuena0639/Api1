using Api1.Model;
using Api1.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api1.Services
{
    public class EmployeeService
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeeService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public async Task<List<Employees>> GetAllEmployees()
        {
            return await _employeesRepository.GetAll();
        }

        public async Task<Employees> GetEmployee(int employeeID)
        {
            return await _employeesRepository.GetEmployees(employeeID);
        }

        public async Task<Employees> CreateEmployee(int employeeID, string name, string lastName, string charge, int departmentID)
        {
            return await _employeesRepository.CreateEmployees(employeeID, name, lastName, charge, departmentID);
        }

        public async Task<Employees> UpdateEmployee(Employees employee)
        {
            return await _employeesRepository.UpdateEmployees(employee);
        }

        public async Task<Employees> DeleteEmployee(int employeeID)
        {
            return await _employeesRepository.DeleteEmployees(employeeID);
        }
    }
}
