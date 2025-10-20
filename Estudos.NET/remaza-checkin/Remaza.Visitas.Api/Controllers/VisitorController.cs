using Microsoft.AspNetCore.Mvc;
using Remaza.Api.Dtos;
using Remaza.Visitas.Api.Dtos;
using Remaza.Visitas.Application.Interfaces;
using Remaza.Visitas.Application.Services;
using Remaza.Visitas.Domain.Entities;
using Remaza.Visitas.Dtos;

namespace Remaza.Visitas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorController : ControllerBase
    {
        private readonly CheckInService _checkInService;
        private readonly IVisitorRepository _visitorRepository;

        public VisitorController(CheckInService checkInService, IVisitorRepository visitorRepository)
        {
            _checkInService = checkInService;
            _visitorRepository = visitorRepository;
        }

        [HttpPost("CheckIn")]
        public async Task<ActionResult<CheckInResponseDto>> CheckIn([FromBody] CheckInRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var responseDto = await _checkInService.HandleCheckInAsync(
                    request.Name,
                    request.Document,
                    request.Type,
                    request.VisitPurpose
                );

                return Ok(responseDto);
            }
            catch (System.ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<VisitorSummaryDto>>> GetAllCheckIns()
        {
            var checkIns = await _visitorRepository.GetAllCheckInsAsync();

            var dtos = checkIns.Select(c => new VisitorSummaryDto
            {
                Name = c.Visitor.Name,
                Document = c.Visitor.Document,
                Type = c.Type,
                VisitPurpose = c.VisitPurpose,
                LastVisit = c.CheckInTime.ToString("dd/MM/yyyy HH:mm:ss")
            }).ToList();

            return Ok(dtos);
        }

        [HttpGet("RecentCheckIns")]
        public async Task<ActionResult<IEnumerable<VisitorSummaryDto>>> GetRecentCheckIns([FromQuery] int count = 5)
        {
            var checkIns = await _visitorRepository.GetRecentCheckInsAsync(count);

            var dtos = checkIns.Select(c => new VisitorSummaryDto
            {
                Name = c.Visitor.Name,
                Document = c.Visitor.Document,
                Type = c.Type,
                VisitPurpose = c.VisitPurpose,
                LastVisit = c.CheckInTime.ToString("HH:mm")
            }).ToList();

            return Ok(dtos);
        }

        [HttpGet("DailyStats")]
        public async Task<ActionResult<DailyStatsDto>> GetDailyStats()
        {
            var stats = await _visitorRepository.GetDailyCheckInStatsAsync();
            return Ok(stats);
        }

        [HttpGet("Search")]
        public async Task<ActionResult<List<Visitor>>> SearchVisitors([FromQuery] string q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return BadRequest("O termo de busca (q) não pode ser vazio.");
            }

            var visitors = await _visitorRepository.SearchVisitorsAsync(q);

            return Ok(visitors);
        }
    }
}