using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESC2020.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ESC2020.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectionController : ControllerBase
    {
        private readonly ESCContext _context;

        public ElectionController(ESCContext context)
        {
            _context = context;
        }

        // GET: api/Election
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Election>>> Getelection()
        {
            return await _context.Elections.ToListAsync();
        }

        // GET: api/Election/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Election>> GetElection(int id)
        {
            var election = await _context.Elections.FindAsync(id);

            if (election == null)
            {
                return NotFound();
            }

            return election;
        }

        // PUT: api/Election/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElection(int id, Election election)
        {
            if (id != election.ElectionId)
            {
                return BadRequest();
            }

            _context.Entry(election).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectionExists(id))
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

        // POST: api/Election
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Election>> PostSession(Election election)
        {
            _context.Elections.Add(election);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetElection), new { id = election.ElectionId }, election);
        }

        // DELETE: api/Election/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Election>> DeleteSession(int id)
        {
            var election = await _context.Elections.FindAsync(id);
            if (election == null)
            {
                return NotFound();
            }

            _context.Elections.Remove(election);
            await _context.SaveChangesAsync();

            return election;
        }

        private bool ElectionExists(int id)
        {
            return _context.Elections.Any(e => e.ElectionId == id);
        }
    }
}
