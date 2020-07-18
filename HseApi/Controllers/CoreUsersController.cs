using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HseApi.Models;

namespace HseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoreUsersController : ControllerBase
    {
        private readonly hse_dev_2019Context _context;

        public CoreUsersController(hse_dev_2019Context context)
        {
            _context = context;
        }

        // GET: api/CoreUsers
        [HttpGet]
        public IEnumerable<CoreUser> GetCoreUser()
        {
            return _context.CoreUser;
        }

        // GET: api/CoreUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoreUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coreUser = await _context.CoreUser.FindAsync(id);

            if (coreUser == null)
            {
                return NotFound();
            }

            return Ok(coreUser);
        }

        // PUT: api/CoreUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoreUser([FromRoute] Guid id, [FromBody] CoreUser coreUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coreUser.Uuid)
            {
                return BadRequest();
            }

            _context.Entry(coreUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoreUserExists(id))
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

        // POST: api/CoreUsers
        [HttpPost]
        public async Task<IActionResult> PostCoreUser([FromBody] CoreUser coreUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CoreUser.Add(coreUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CoreUserExists(coreUser.Uuid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCoreUser", new { id = coreUser.Uuid }, coreUser);
        }

        // DELETE: api/CoreUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoreUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coreUser = await _context.CoreUser.FindAsync(id);
            if (coreUser == null)
            {
                return NotFound();
            }

            _context.CoreUser.Remove(coreUser);
            await _context.SaveChangesAsync();

            return Ok(coreUser);
        }

        private bool CoreUserExists(Guid id)
        {
            return _context.CoreUser.Any(e => e.Uuid == id);
        }
    }
}