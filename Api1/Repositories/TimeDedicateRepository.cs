using Api1.Context;
using Api1.Model;
using Microsoft.EntityFrameworkCore;

namespace api1st.Repositories
{
    public interface UITimeDedicated
    {
        Task<List<TimeDedicated>> GetAll();
        Task<TimeDedicated> GetTimeDedicated(int TimeDedicatedId);
        Task<TimeDedicated> CreateTimeDedicated(int timeDedicatedId, int employeeId, DateTime date, int iDProyect, int workedHours);
        Task<TimeDedicated> UpdateTimeDedicated(TimeDedicated timeDedicated);
        Task<TimeDedicated> DeleteTimeDedicated(int TimeDedicatedId);

    }
    public class TimeDedicateRepository : UITimeDedicated
    {
        private readonly BaseEj4 _db;

        public TimeDedicateRepository(BaseEj4 db)
        {
            _db = db;
        }
        public async Task<List<TimeDedicated>> GetAll()
        {
            return await _db.TimeDedicated.ToListAsync();
        }

        public async Task<TimeDedicated> GetTimeDedicated(int timeDedicatedId)
        {
            return await _db.TimeDedicated.FirstOrDefaultAsync(t => t.TimeDedicatedId == timeDedicatedId);
        }
        public async Task<TimeDedicated> CreateTimeDedicated(int timeDedicatedId, int employeeId, DateTime date, int iDProyect, int workedHours)
        {
            TimeDedicated timeDedicated = new TimeDedicated
            {
                TimeDedicatedId = timeDedicatedId,
                EmployeeId = employeeId,
                Date = date,
                IDProyect = iDProyect,
                WorkedHours = workedHours
            };

            await _db.TimeDedicated.AddAsync(timeDedicated);
            _db.SaveChanges();
            return timeDedicated;

        }

        public async Task<TimeDedicated> UpdateTimeDedicated(TimeDedicated timeDedicated)
        {
            _db.TimeDedicated.Update(timeDedicated);
            await _db.SaveChangesAsync();
            return timeDedicated;
        }

        public async Task<TimeDedicated> DeleteTimeDedicated(int TimeDedicatedId)
        {
            TimeDedicated timeDedicated = await GetTimeDedicated(TimeDedicatedId);
            _db.TimeDedicated.Remove(timeDedicated);
            await _db.SaveChangesAsync();
            return timeDedicated;
        }

    }
}
