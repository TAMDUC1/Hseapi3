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
    public class CoreFileUploads1Controller : ControllerBase
    {
        private readonly hse_dev_2019Context _context;

        public CoreFileUploads1Controller(hse_dev_2019Context context)
        {
            _context = context;
        }

        // GET: api/CoreFileUploads1
        [HttpGet]
        public IEnumerable<CoreFileUpload> GetCoreFileUpload()
        {
            return _context.CoreFileUpload;
        }

        [HttpGet("{id:guid}")]
        public IEnumerable<CoreFileUpload> GetFileUploadMobile([FromRoute] Guid id)
        {
            var temp = _context.CoreFileUpload.ToList();
            temp = temp.FindAll(e => e.ModelUuid == id);
            return temp;
        }

        // PUT: api/CoreFileUploads1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoreFileUpload([FromRoute] Guid id, [FromBody] CoreFileUpload coreFileUpload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coreFileUpload.Uuid)
            {
                return BadRequest();
            }

            _context.Entry(coreFileUpload).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoreFileUploadExists(id))
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

        // POST: api/CoreFileUploads1
        [HttpPost]
        public async Task<IActionResult> PostCoreFileUpload([FromBody] CoreFileUpload coreFileUpload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CoreFileUpload.Add(coreFileUpload);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CoreFileUploadExists(coreFileUpload.Uuid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCoreFileUpload", new { id = coreFileUpload.Uuid }, coreFileUpload);
        }

        // DELETE: api/CoreFileUploads1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoreFileUpload([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coreFileUpload = await _context.CoreFileUpload.FindAsync(id);
            if (coreFileUpload == null)
            {
                return NotFound();
            }

            _context.CoreFileUpload.Remove(coreFileUpload);
            await _context.SaveChangesAsync();

            return Ok(coreFileUpload);
        }

        private bool CoreFileUploadExists(Guid id)
        {
            return _context.CoreFileUpload.Any(e => e.Uuid == id);
        }
    }
}