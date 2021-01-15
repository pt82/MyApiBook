using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApiBook.Models;

namespace MyApiBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public SexesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Sexes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sex>>> GetSexes()
        {
            return await _context.Sexes.ToListAsync();
        }

        // GET: api/Sexes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sex>> GetSex(int id)
        {
            var sex = await _context.Sexes.FindAsync(id);

            if (sex == null)
            {
                return NotFound();
            }

            return sex;
        }

        // PUT: api/Sexes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSex(int id, Sex sex)
        {
            if (id != sex.Id)
            {
                return BadRequest();
            }

            _context.Entry(sex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SexExists(id))
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

        // POST: api/Sexes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sex>> PostSex(Sex sex)
        {
            _context.Sexes.Add(sex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSex", new { id = sex.Id }, sex);
        }

        // DELETE: api/Sexes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sex>> DeleteSex(int id)
        {
            var sex = await _context.Sexes.FindAsync(id);
            if (sex == null)
            {
                return NotFound();
            }

            _context.Sexes.Remove(sex);
            await _context.SaveChangesAsync();

            return sex;
        }

        private bool SexExists(int id)
        {
            return _context.Sexes.Any(e => e.Id == id);
        }
    }
}
