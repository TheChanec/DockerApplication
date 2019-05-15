using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DockerProject;
using DockerProject.Models;

namespace DockerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityTest2Controller : ControllerBase
    {
        private readonly DockerProjectContext _context;

        public EntityTest2Controller(DockerProjectContext context)
        {
            _context = context;
        }

        // GET: api/EntityTest2
        [HttpGet]
        public IEnumerable<EntityTest2> GetEntityTest2()
        {
            return _context.EntityTest2;
        }

        // GET: api/EntityTest2/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityTest2([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityTest2 = await _context.EntityTest2.FindAsync(id);

            if (entityTest2 == null)
            {
                return NotFound();
            }

            return Ok(entityTest2);
        }

        // PUT: api/EntityTest2/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityTest2([FromRoute] int id, [FromBody] EntityTest2 entityTest2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entityTest2.ID)
            {
                return BadRequest();
            }

            _context.Entry(entityTest2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityTest2Exists(id))
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

        // POST: api/EntityTest2
        [HttpPost]
        public async Task<IActionResult> PostEntityTest2([FromBody] EntityTest2 entityTest2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EntityTest2.Add(entityTest2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityTest2", new { id = entityTest2.ID }, entityTest2);
        }

        // DELETE: api/EntityTest2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityTest2([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityTest2 = await _context.EntityTest2.FindAsync(id);
            if (entityTest2 == null)
            {
                return NotFound();
            }

            _context.EntityTest2.Remove(entityTest2);
            await _context.SaveChangesAsync();

            return Ok(entityTest2);
        }

        private bool EntityTest2Exists(int id)
        {
            return _context.EntityTest2.Any(e => e.ID == id);
        }
    }
}