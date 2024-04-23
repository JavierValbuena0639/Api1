using Api1.Model;
using Api1.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api1.Services
{
    public class DepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<List<Departaments>> GetAllDepartments()
        {
            return await _departmentRepository.GetAll();
        }

        public async Task<Departaments> GetDepartment(int departmentID)
        {
            return await _departmentRepository.GetDepartment(departmentID);
        }

        public async Task<Departaments> CreateDepartment(int departmentID, string name)
        {
            return await _departmentRepository.CreateDepartment(departmentID, name);
        }

        public async Task<Departaments> UpdateDepartment(Departaments department)
        {
            return await _departmentRepository.UpdateDepartment(department);
        }

        public async Task<Departaments> DeleteDepartment(int departmentID)
        {
            return await _departmentRepository.DeleteDepartment(departmentID);
        }
    }
}
