using DashboardWS.Data;
using DashboardWS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DashboardWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StatusesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStatuses()
        {
            return Ok(_context.Statuses.ToList());
        }

        [HttpPost]
        public  IActionResult UpdateStatus(Status status)
        {
            _context.Statuses.Add(status);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetStatuses), new { id = status.Id }, status);
        }

    }
}
