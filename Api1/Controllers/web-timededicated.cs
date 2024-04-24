using Api1.Model;
using Api1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeDedicatedController : ControllerBase
    {
        private readonly TimeDedicatedService _timeDedicatedService;

        public TimeDedicatedController(TimeDedicatedService timeDedicatedService)
        {
            _timeDedicatedService = timeDedicatedService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TimeDedicated>>> GetAllTimeDedicated()
        {
            return Ok(await _timeDedicatedService.GetAllTimeDedicated());
        }

        [HttpGet("{timeDedicatedId}")]
        public async Task<ActionResult<TimeDedicated>> GetTimeDedicated(int timeDedicatedId)
        {
            var timeDedicated = await _timeDedicatedService.GetTimeDedicated(timeDedicatedId);
            if (timeDedicated == null)
            {
                return BadRequest("Tiempo dedicado no encontrado");
            }
            return Ok(timeDedicated);
        }

        [HttpPost]
        public async Task<ActionResult<TimeDedicated>> CreateTimeDedicated([FromBody] TimeDedicated timeDedicated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _timeDedicatedService.CreateTimeDedicated(timeDedicated.TimeDedicatedId, timeDedicated.EmployeeId, timeDedicated.Date, timeDedicated.ProjectId, timeDedicated.WorkedHours));
        }

        [HttpPut("{timeDedicatedId}")]
        public async Task<ActionResult<TimeDedicated>> UpdateTimeDedicated(int timeDedicatedId, [FromBody] TimeDedicated timeDedicated)
        {
            if (timeDedicatedId != timeDedicated.TimeDedicatedId)
            {
                return BadRequest("IDs de tiempo dedicado no coinciden");
            }

            var existingTimeDedicated = await _timeDedicatedService.GetTimeDedicated(timeDedicatedId);
            if (existingTimeDedicated == null)
            {
                return NotFound("Tiempo dedicado no encontrado");
            }

            return Ok(await _timeDedicatedService.UpdateTimeDedicated(timeDedicated));
        }

        [HttpDelete("{timeDedicatedId}")]
        public async Task<ActionResult<TimeDedicated>> DeleteTimeDedicated(int timeDedicatedId)
        {
            var existingTimeDedicated = await _timeDedicatedService.GetTimeDedicated(timeDedicatedId);
            if (existingTimeDedicated == null)
            {
                return NotFound("Tiempo dedicado no encontrado");
            }

            return Ok(await _timeDedicatedService.DeleteTimeDedicated(timeDedicatedId));
        }
    }
}
