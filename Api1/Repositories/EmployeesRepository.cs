using Api1.Context;
using Api1.Model;
using Microsoft.EntityFrameworkCore;

namespace Api1.Repositories
{
    public interface IEmployeesRepository
    {
        Task<List<Employees>> GetAll();
        Task<Employees> GetEmployees(int IDEmployee);
        Task<Employees> CreateEmployees(int idEmployee, string name, string lasname, string charge, int idDepartament);
        Task<Employees> UpdateEmployees(Employees Employees);
        Task<Employees> DeleteEmployees(int IDEmployee);

    }


    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly BaseEj4 _db;

        public EmployeesRepository(BaseEj4 db)
        {
            _db = db;
        }
        public async Task<List<Employees>> GetAll()
        {
            return await _db.Employees.ToListAsync();
        }

        public async Task<Employees> GetEmployees(int iDEmployee)
        {
            return _db.Employees.FirstOrDefault(u => u.IDEmployee == iDEmployee);
        }
        public async Task<Employees> CreateEmployees(int idEmployee, string name, string lasname, string charge, int idDepartament)
        {
            Employees newEmployees = new Employees
            {
                IDEmployee = idEmployee,
                Name = name,
                Lastname = lasname,
                Charge = charge,
                IDDepartament = idDepartament,
            };

            await _db.Employees.AddAsync(newEmployees);
            _db.SaveChanges();
            return newEmployees;
        }

        public async Task<Employees> UpdateEmployees(Employees Employees)
        {
           _db.Employees.Update(Employees);
            await _db.SaveChangesAsync();
            return Employees;
        }
        public async Task<Employees> DeleteEmployees(int IDEmployee)
        {
            Employees Employees = await GetEmployees(IDEmployee);
            
            _db.Employees.Remove(Employees);
            await _db.SaveChangesAsync();
            return Employees;
        }
    }
}
