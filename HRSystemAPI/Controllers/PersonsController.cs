using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRSystemAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSystemAPI.Data;

namespace HRSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly HRDbContext _hRDbContext;

        public PersonsController(HRDbContext hRDbContext)
        {
            _hRDbContext = hRDbContext;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            return await _hRDbContext.Persons.ToListAsync();
        }

        // GET: api/Persons
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _hRDbContext.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/Persons
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _hRDbContext.Entry(person).State = EntityState.Modified;

            try
            {
                await _hRDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Persons
        [HttpPost]
        public async Task<ActionResult<Person>> AddPerson(Person person)
        {
            _hRDbContext.Persons.Add(person);
            await _hRDbContext.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/Persons
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _hRDbContext.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _hRDbContext.Persons.Remove(person);
            await _hRDbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _hRDbContext.Persons.Any(e => e.Id == id);
        }
    }
}