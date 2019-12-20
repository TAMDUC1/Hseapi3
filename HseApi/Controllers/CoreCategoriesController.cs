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
    public class CoreCategoriesController : ControllerBase
    {
        private readonly hse_dev_2019Context _context;

        public CoreCategoriesController(hse_dev_2019Context context)
        {
            _context = context;
        }

        // GET: api/CoreCategories
        [HttpGet]
        public IEnumerable<CoreCategory> GetCoreCategory()
        {
            return _context.CoreCategory;
        }

        // GET: api/CoreCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoreCategory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coreCategory = await _context.CoreCategory.FindAsync(id);

            if (coreCategory == null)
            {
                return NotFound();
            }

            return Ok(coreCategory);
        }

        // PUT: api/CoreCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoreCategory([FromRoute] Guid id, [FromBody] CoreCategory coreCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coreCategory.Uuid)
            {
                return BadRequest();
            }

            _context.Entry(coreCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoreCategoryExists(id))
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

        // POST: api/CoreCategories
        [HttpPost]
        public async Task<IActionResult> PostCoreCategory([FromBody] CoreCategory coreCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CoreCategory.Add(coreCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CoreCategoryExists(coreCategory.Uuid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCoreCategory", new { id = coreCategory.Uuid }, coreCategory);
        }

        // DELETE: api/CoreCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoreCategory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coreCategory = await _context.CoreCategory.FindAsync(id);
            if (coreCategory == null)
            {
                return NotFound();
            }

            _context.CoreCategory.Remove(coreCategory);
            await _context.SaveChangesAsync();

            return Ok(coreCategory);
        }

        private bool CoreCategoryExists(Guid id)
        {
            return _context.CoreCategory.Any(e => e.Uuid == id);
        }
    }
}