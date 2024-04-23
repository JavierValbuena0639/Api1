using Api1.Context;
using Api1.Model;
using Microsoft.EntityFrameworkCore;

namespace Api1.Repositories
{
    public interface UIProjects
    {
        Task<List<Projects>> GetAll();
        Task<Projects> GetProjects(int ProjectId);
        Task<Projects> CreateProjects(int projectId, string nameProject, string description, DateTime startDate, DateTime endDate);
        Task<Projects> UpdateProjects(Projects Projects);
        Task<Projects> DeleteProjects(int ProjectId);

    }

    public class ProjectRepository : UIProjects
    {
        private readonly BaseEj4 _db;

        public ProjectRepository(BaseEj4 db)
        {
            _db = db;
        }
        public async Task<List<Projects>> GetAll()
        {
            return await _db.Projects.ToListAsync();
        }

        public async Task<Projects> GetProjects(int ProjectId)
        {
           return await _db.Projects.FirstAsync(p => p.ProjectId == ProjectId);
        }
        public async Task<Projects> CreateProjects(int projectId, string nameProject, string description, DateTime startDate, DateTime endDate)
        {
            Projects newProjects = new Projects
            {
                ProjectId = projectId,
                NameProject = nameProject,
                Description = description,
                StartDate = startDate,
                EndDate = endDate
            };

            await _db.Projects.AddAsync(newProjects);
            _db.SaveChanges();
            return newProjects;
        }
        public async Task<Projects> UpdateProjects(Projects Projects)
        {
            _db.Projects.Update(Projects);
            await _db.SaveChangesAsync();
            return Projects;
        
        }
        public async Task<Projects> DeleteProjects(int ProjectId)
        {
            Projects Projects = await GetProjects(ProjectId);
            _db.Projects.Remove(Projects);
            await _db.SaveChangesAsync();
            return Projects;
        }
    }
}
