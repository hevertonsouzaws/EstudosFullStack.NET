using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DashboardWS.Data;
using DashboardWS.Models;
using Microsoft.EntityFrameworkCore;


namespace DashboardWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_context.Employees.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

    }

}


/* ex: Aula Balta 
     public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var employee = await context
                .Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return employee == null
                ? NotFound()
                : Ok(employee);
        }
    }*/