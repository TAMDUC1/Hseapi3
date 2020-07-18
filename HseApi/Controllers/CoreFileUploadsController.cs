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
    public class CoreFileUploadsController : ControllerBase
    {
        private readonly hse_dev_2019Context _context;

        public CoreFileUploadsController(hse_dev_2019Context context)
        {
            _context = context;
        }

        // GET: api/CoreFileUploads
        [HttpGet]
        public IEnumerable<CoreFileUpload> GetCoreFileUpload()
        {

            return _context.CoreFileUpload;
        }
        // GET api/FileUploadMobile/b7f448dc-1451-477a-87f9-9214d1621c20
        //    [Route("FileUploadMobile/{uuid:guid}")]
        //    [HttpGet("{uuid}")]
        ////    https://localhost:44353/api/CoreFileUploads/GetFileUploadMobile/b7f448dc-1451-477a-87f9-9214d1621c20
        //    public IEnumerable<CoreFileUpload> GetFileUploadMobile([FromRoute] Guid uuid)
        //    {

        //        var temp = _context.CoreFileUpload.ToList();
        //        temp = temp.FindAll(e => e.ModelUuid == uuid && e.Model == "hse_audit" && e.Module == "hse");
        //        return _context.CoreFileUpload;
        //    }

        // lay danh sach file theo uuid cua audit
        // GET: api/CoreFileUploads/b7f448dc-1451-477a-87f9-9214d1621c20
        [HttpGet("{id:guid}")]
        public IEnumerable<CoreFileUpload> GetFileUploadMobile([FromRoute] Guid id)
        {
            var temp = _context.CoreFileUpload.ToList();
            temp = temp.FindAll(e => e.ModelUuid == id && e.Model == "hse_audit" && e.Module == "hse");
            return temp;
        }

        public IEnumerable<CoreFileUpload> GetDocUploadMobile([FromRoute] Guid id)
        {
            var temp = _context.CoreFileUpload.ToList();
            temp = temp.FindAll(e => e.ModelUuid == id);
            return temp;
        }




        // GET: api/CoreFileUploads/b7f448dc-1451-477a-87f9-9214d1621c20
        //[HttpGet("{id:guid}")]
        //public async Task<IActionResult> GetCoreFileUpload([FromRoute] Guid id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var coreFileUpload = await _context.CoreFileUpload.FindAsync(id);

        //    if (coreFileUpload == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(coreFileUpload);
        //}

        // PUT: api/CoreFileUploads/5
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

        // POST: api/CoreFileUploads
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

        // DELETE: api/CoreFileUploads/5
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

            // DELETE FILE



            // DELETE RECORD

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