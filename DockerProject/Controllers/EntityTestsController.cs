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
    public class EntityTestsController : ControllerBase
    {
        private readonly DockerProjectContext _context;

        public EntityTestsController(DockerProjectContext context)
        {
            _context = context;
        }

        // GET: api/EntityTests
        [HttpGet]
        public IEnumerable<EntityTest> GetEntityTest()
        {
            return _context.EntityTest;
        }

        // GET: api/EntityTests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityTest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityTest = await _context.EntityTest.FindAsync(id);

            if (entityTest == null)
            {
                return NotFound();
            }

            return Ok(entityTest);
        }

        // PUT: api/EntityTests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityTest([FromRoute] int id, [FromBody] EntityTest entityTest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entityTest.Id)
            {
                return BadRequest();
            }

            _context.Entry(entityTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityTestExists(id))
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

        // POST: api/EntityTests
        [HttpPost]
        public async Task<IActionResult> PostEntityTest([FromBody] EntityTest entityTest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EntityTest.Add(entityTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityTest", new { id = entityTest.Id }, entityTest);
        }

        // DELETE: api/EntityTests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityTest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityTest = await _context.EntityTest.FindAsync(id);
            if (entityTest == null)
            {
                return NotFound();
            }

            _context.EntityTest.Remove(entityTest);
            await _context.SaveChangesAsync();

            return Ok(entityTest);
        }

        private bool EntityTestExists(int id)
        {
            return _context.EntityTest.Any(e => e.Id == id);
        }
    }
}