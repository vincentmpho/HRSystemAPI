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
        [Route("api/[controller]")]
        [ApiController]
        public class DepartmentsController : ControllerBase
        {
            private readonly HRDbContext _hRDbContext;

            public DepartmentsController(HRDbContext context)
            {
                _hRDbContext = context;
            }

            // GET: api/Departments
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
            {
                var departments = await _hRDbContext.Departments.ToListAsync();
                return Ok(departments);
            }

            // GET: api/Departments
            [HttpGet("{id}")]
            public async Task<ActionResult<Department>> GetDepartment(int id)
            {
                var department = await _hRDbContext.Departments.FindAsync(id);

                if (department == null)
                {
                    return NotFound();
                }

                return Ok(department);
            }
        }
    }
}