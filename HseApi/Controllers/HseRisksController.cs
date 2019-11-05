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
    public class HseRisksController : ControllerBase
    {
        private readonly hse_dev_2019Context _context;

        public HseRisksController(hse_dev_2019Context context)
        {
            _context = context;
        }

        // GET: api/HseRisks
        [HttpGet]
        public IEnumerable<HseRisk> GetHseRisk()
        {
            return _context.HseRisk;
        }

        // GET: api/HseRisks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHseRisk([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hseRisk = await _context.HseRisk.FindAsync(id);

            if (hseRisk == null)
            {
                return NotFound();
            }

            return Ok(hseRisk);
        }

        // PUT: api/HseRisks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHseRisk([FromRoute] Guid id, [FromBody] HseRisk hseRisk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hseRisk.Uuid)
            {
                return BadRequest();
            }

            _context.Entry(hseRisk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HseRiskExists(id))
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

        // POST: api/HseRisks
        [HttpPost]
        public async Task<IActionResult> PostHseRisk([FromBody] HseRisk hseRisk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HseRisk.Add(hseRisk);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HseRiskExists(hseRisk.Uuid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHseRisk", new { id = hseRisk.Uuid }, hseRisk);
        }

        // DELETE: api/HseRisks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHseRisk([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hseRisk = await _context.HseRisk.FindAsync(id);
            if (hseRisk == null)
            {
                return NotFound();
            }

            _context.HseRisk.Remove(hseRisk);
            await _context.SaveChangesAsync();

            return Ok(hseRisk);
        }

        private bool HseRiskExists(Guid id)
        {
            return _context.HseRisk.Any(e => e.Uuid == id);
        }
    }
}