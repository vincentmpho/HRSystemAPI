using HRSystemAPI.Data;
using HRSystemAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        private readonly HRDbContext _hRDbContext;

        public SalariesController(HRDbContext context)
        {
            _hRDbContext = context;
        }

        // GET: api/Salaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salary>>> GetSalaries()
        {
            var salaries = await _hRDbContext.Salarys.ToListAsync();
            return Ok(salaries);
        }

        // GET: api/Salaries
        [HttpGet("{id}")]
        public async Task<ActionResult<Salary>> GetSalary(int id)
        {
            var salary = await _hRDbContext.Salarys.FindAsync(id);

            if (salary == null)
            {
                return NotFound();
            }

            return Ok(salary);
        }
    }
}
