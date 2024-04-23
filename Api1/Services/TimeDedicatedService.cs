using Api1.Model;
using Api1.Repositories;
using api1st.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api1.Services
{
    public class TimeDedicatedService
    {
        private readonly UITimeDedicated _timeDedicatedRepository;

        public TimeDedicatedService(UITimeDedicated timeDedicatedRepository)
        {
            _timeDedicatedRepository = timeDedicatedRepository;
        }

        public async Task<List<TimeDedicated>> GetAllTimeDedicated()
        {
            return await _timeDedicatedRepository.GetAll();
        }

        public async Task<TimeDedicated> GetTimeDedicated(int timeDedicatedId)
        {
            return await _timeDedicatedRepository.GetTimeDedicated(timeDedicatedId);
        }

        public async Task<TimeDedicated> CreateTimeDedicated(int timeDedicatedId, int employeeId, DateTime date, int projectId, int workedHours)
        {
            return await _timeDedicatedRepository.CreateTimeDedicated(timeDedicatedId, employeeId, date, projectId, workedHours);
        }

        public async Task<TimeDedicated> UpdateTimeDedicated(TimeDedicated timeDedicated)
        {
            return await _timeDedicatedRepository.UpdateTimeDedicated(timeDedicated);
        }

        public async Task<TimeDedicated> DeleteTimeDedicated(int timeDedicatedId)
        {
            return await _timeDedicatedRepository.DeleteTimeDedicated(timeDedicatedId);
        }
    }
}
