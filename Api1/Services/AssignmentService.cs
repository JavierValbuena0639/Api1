using Api1.Model;
using Api1.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api1.Services
{
    public class AssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<List<Assignments>> GetAllAssignments()
        {
            return await _assignmentRepository.GetAll();
        }

        public async Task<Assignments> GetAssignment(int assignmentId)
        {
            return await _assignmentRepository.GetAssignment(assignmentId);
        }

        public async Task<Assignments> CreateAssignment(int employeeID, int projectID, DateTime startDate, DateTime assignmentDate, string assignmentHours)
        {
            return await _assignmentRepository.CreateAssignment(employeeID, projectID, startDate, assignmentDate, assignmentHours);
        }

        public async Task<Assignments> UpdateAssignment(int assignmentId, int employeeID, int projectID, DateTime startDate, DateTime assignmentDate, string assignmentHours)
        {
            var existingAssignment = await _assignmentRepository.GetAssignment(assignmentId);
            if (existingAssignment == null)
            {
                // Handle error if assignment doesn't exist
                return null;
            }

            existingAssignment.EmployeeID = employeeID;
            existingAssignment.IDProject = projectID;
            existingAssignment.StartDate = startDate;
            existingAssignment.AssignmentDate = assignmentDate;
            existingAssignment.AssignmentHours = assignmentHours;

            return await _assignmentRepository.UpdateAssignment(assignmentId, existingAssignment);
        }

        public async Task<Assignments> DeleteAssignment(int assignmentId)
        {
            return await _assignmentRepository.DeleteAssignment(assignmentId);
        }
    }
}
