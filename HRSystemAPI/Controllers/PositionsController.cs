using HRSystemAPI.Data;
using HRSystemAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly HRDbContext _hRDbContext;

        public PositionsController(HRDbContext context)
        {
            _hRDbContext = context;
        }

        // GET: api/Positions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> GetPositions()
        {
            var positions = await _hRDbContext.Positions.ToListAsync();
            return Ok(positions);
        }

        // GET: api/Positions
        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> GetPosition(int id)
        {
            var position = await _hRDbContext.Positions.FindAsync(id);

            if (position == null)
            {
                return NotFound();
            }

            return Ok(position);
        }
    }

}
