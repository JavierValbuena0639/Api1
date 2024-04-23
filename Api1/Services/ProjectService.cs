using Api1.Model;
using Api1.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api1.Services
{
    public class ProjectService
    {
        private readonly UIProjects _projectRepository;

        public ProjectService(UIProjects projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<Projects>> GetAllProjects()
        {
            return await _projectRepository.GetAll();
        }

        public async Task<Projects> GetProject(int projectId)
        {
            return await _projectRepository.GetProjects(projectId);
        }

        public async Task<Projects> CreateProject(int projectId, string nameProject, string description, DateTime startDate, DateTime endDate)
        {
            return await _projectRepository.CreateProjects(projectId, nameProject, description, startDate, endDate);
        }

        public async Task<Projects> UpdateProject(Projects project)
        {
            return await _projectRepository.UpdateProjects(project);
        }

        public async Task<Projects> DeleteProject(int projectId)
        {
            return await _projectRepository.DeleteProjects(projectId);
        }
    }
}
