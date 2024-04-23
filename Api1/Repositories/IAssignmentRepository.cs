using Api1.Context;
using Api1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api1.Repositories
{
    public interface IAssignmentRepository
    {
        Task<List<Assignments>> GetAll();
        Task<Assignments> GetAssignment(int assignmentId);
        Task<Assignments> CreateAssignment(int employeeID, int projectID, DateTime startDate, DateTime assignmentDate, string assignmentHours);
        Task<Assignments> UpdateAssignment(int assignmentId, Assignments updatedAssignment);
        Task<Assignments> DeleteAssignment(int assignmentId);
    }

    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly BaseEj4 _db;

        public AssignmentRepository(BaseEj4 db)
        {
            _db = db;
        }

        public async Task<List<Assignments>> GetAll()
        {
            return await _db.Assignments.ToListAsync();
        }

        public async Task<Assignments> GetAssignment(int assignmentId)
        {
            return await _db.Assignments.FirstOrDefaultAsync(u => u.AssignmentId == assignmentId);
        }

        public async Task<Assignments> CreateAssignment(int employeeID, int projectID, DateTime startDate, DateTime assignmentDate, string assignmentHours)
        {
            Assignments newAssignment = new Assignments
            {
                EmployeeID = employeeID,
                IDProject = projectID,
                StartDate = startDate,
                AssignmentDate = assignmentDate,
                AssignmentHours = assignmentHours
            };

            await _db.Assignments.AddAsync(newAssignment);
            await _db.SaveChangesAsync();

            return newAssignment;
        }

        public async Task<Assignments> UpdateAssignment(int assignmentId, Assignments updatedAssignment)
        {
            var assignment = await GetAssignment(assignmentId);
            if (assignment == null)
                return null;

            assignment.EmployeeID = updatedAssignment.EmployeeID;
            assignment.IDProject = updatedAssignment.IDProject;
            assignment.StartDate = updatedAssignment.StartDate;
            assignment.AssignmentDate = updatedAssignment.AssignmentDate;
            assignment.AssignmentHours = updatedAssignment.AssignmentHours;

            await _db.SaveChangesAsync();
            return assignment;
        }

        public async Task<Assignments> DeleteAssignment(int assignmentId)
        {
            var assignment = await GetAssignment(assignmentId);
            if (assignment == null)
                return null;

            _db.Assignments.Remove(assignment);
            await _db.SaveChangesAsync();

            return assignment;
        }
    }
}
