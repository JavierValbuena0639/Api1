using Api1.Context;
using Api1.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api1.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Departaments>> GetAll();
        Task<Departaments> GetDepartment(int departmentID);
        Task<Departaments> CreateDepartment(int departmentID, string name);
        Task<Departaments> UpdateDepartment(Departaments department);
        Task<Departaments> DeleteDepartment(int departmentID);
    }

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly BaseEj4 _db;

        public DepartmentRepository(BaseEj4 db)
        {
            _db = db;
        }

        public async Task<List<Departaments>> GetAll()
        {
            return await _db.Departments.ToListAsync();
        }

        public async Task<Departaments> GetDepartment(int departmentID)
        {
            return await _db.Departments.FirstOrDefaultAsync(u => u.DepartamentID == departmentID);
        }

        public async Task<Departaments> CreateDepartment(int departmentID, string name)
        {
            Departaments newDepartment = new Departaments
            {
                DepartamentID = departmentID,
                Name = name
            };

            await _db.Departments.AddAsync(newDepartment);
            await _db.SaveChangesAsync();
            return newDepartment;
        }

        public async Task<Departaments> UpdateDepartment(Departaments department)
        {
            _db.Departments.Update(department);
            await _db.SaveChangesAsync();
            return department;
        }

        public async Task<Departaments> DeleteDepartment(int departmentID)
        {
            Departaments department = await GetDepartment(departmentID);
            if (department == null)
            {
                // Handle error if department doesn't exist
                return null;
            }

            _db.Departments.Remove(department);
            await _db.SaveChangesAsync();
            return department;
        }
    }
}
