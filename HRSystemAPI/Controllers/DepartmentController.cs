using HRSystemAPI.Data;
using HRSystemAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly HRDbContext _hRDbContext;

        public DepartmentController(HRDbContext hRDbContext)
        {
            _hRDbContext = hRDbContext;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return StatusCode(StatusCodes.Status200OK, await _hRDbContext.Departments.ToListAsync());
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _hRDbContext.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status200OK, department);
        }

        // POST: api/Department
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            _hRDbContext.Departments.Add(department);
            await _hRDbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created, CreatedAtAction("GetDepartment", new { id = department.Id }, department));
        }

        // PUT: api/Department/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _hRDbContext.Entry(department).State = EntityState.Modified;

            try
            {
                await _hRDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(StatusCodes.Status200OK, department);
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _hRDbContext.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _hRDbContext.Departments.Remove(department);
            await _hRDbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status204NoContent);
        }

        private bool DepartmentExists(int id)
        {
            return _hRDbContext.Departments.Any(e => e.Id == id);
        }
    }
}