﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HseApi.Models;
using Microsoft.AspNetCore.Cors;
namespace HseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HseAuditsController : ControllerBase
    {
        private readonly hse_dev_2019Context _context;

        public HseAuditsController(hse_dev_2019Context context)
        {
            _context = context;
        }

        // GET: api/HseAudits
      //  [EnableCors]
        [HttpGet]
        public IEnumerable<HseAudit> GetHseAudit()
        {
            try
            {
                var results = _context.HseAudit.ToList();
                return results;
            }
            catch (Exception ex) { return null; }
        }

        // GET: api/HseAudits/7496bfbb-092f-4d6a-a269-6af6a52866ee  
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHseAudit([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hseAudit = await _context.HseAudit.FindAsync(id);

            if (hseAudit == null)
            {
                return NotFound();
            }

            return Ok(hseAudit);
        }

        // PUT: api/HseAudits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHseAudit([FromRoute] Guid id, [FromBody] HseAudit hseAudit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hseAudit.Uuid)
            {
                return BadRequest();
            }

            _context.Entry(hseAudit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HseAuditExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new {status = 204});
        }

        // POST: api/HseAudits
        [HttpPost]
        public async Task<IActionResult> PostHseAudit([FromBody] HseAudit hseAudit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HseAudit.Add(hseAudit);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HseAuditExists(hseAudit.Uuid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHseAudit", new { id = hseAudit.Uuid }, hseAudit);
        }

        // DELETE: api/HseAudits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHseAudit([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hseAudit = await _context.HseAudit.FindAsync(id);
            if (hseAudit == null)
            {
                return NotFound();
            }

            _context.HseAudit.Remove(hseAudit);
            await _context.SaveChangesAsync();

            return Ok(hseAudit);
        }

        private bool HseAuditExists(Guid id)
        {
            return _context.HseAudit.Any(e => e.Uuid == id);
        }
    }
}