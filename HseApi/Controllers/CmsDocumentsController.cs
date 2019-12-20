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
    public class CmsDocumentsController : ControllerBase
    {
        private readonly hse_dev_2019Context _context;

        public CmsDocumentsController(hse_dev_2019Context context)
        {
            _context = context;
        }

        // GET: api/CmsDocuments
        [HttpGet]
        public IEnumerable<CmsDocument> GetCmsDocument()
        {
            return _context.CmsDocument;
        }

        // GET: api/CmsDocuments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCmsDocument([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cmsDocument = await _context.CmsDocument.FindAsync(id);

            if (cmsDocument == null)
            {
                return NotFound();
            }

            return Ok(cmsDocument);
        }

        // PUT: api/CmsDocuments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCmsDocument([FromRoute] Guid id, [FromBody] CmsDocument cmsDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cmsDocument.Uuid)
            {
                return BadRequest();
            }

            _context.Entry(cmsDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CmsDocumentExists(id))
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

        // POST: api/CmsDocuments
        [HttpPost]
        public async Task<IActionResult> PostCmsDocument([FromBody] CmsDocument cmsDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CmsDocument.Add(cmsDocument);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CmsDocumentExists(cmsDocument.Uuid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCmsDocument", new { id = cmsDocument.Uuid }, cmsDocument);
        }

        // DELETE: api/CmsDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCmsDocument([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cmsDocument = await _context.CmsDocument.FindAsync(id);
            if (cmsDocument == null)
            {
                return NotFound();
            }

            _context.CmsDocument.Remove(cmsDocument);
            await _context.SaveChangesAsync();

            return Ok(cmsDocument);
        }

        private bool CmsDocumentExists(Guid id)
        {
            return _context.CmsDocument.Any(e => e.Uuid == id);
        }
    }
}