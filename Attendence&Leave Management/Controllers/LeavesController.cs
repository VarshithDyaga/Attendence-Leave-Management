using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Attendence_Leave_Management.Model;

namespace Attendence_Leave_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly Attendance_Leave_Context _context;

        public LeavesController(Attendance_Leave_Context context)
        {
            _context = context;
        }

        // GET: api/Leaves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leaves>>> GetLeaveData()
        {
          if (_context.LeaveData == null)
          {
              return NotFound();
          }
            return await _context.LeaveData.ToListAsync();
        }

        // GET: api/Leaves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Leaves>> GetLeaves(int id)
        {
          if (_context.LeaveData == null)
          {
              return NotFound();
          }
            var leaves = await _context.LeaveData.FindAsync(id);

            if (leaves == null)
            {
                return NotFound();
            }

            return leaves;
        }

        // PUT: api/Leaves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaves(int id, Leaves leaves)
        {
            if (id != leaves.LeaveId)
            {
                return BadRequest();
            }

            _context.Entry(leaves).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeavesExists(id))
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

        // POST: api/Leaves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Leaves>> PostLeaves(Leaves leaves)
        {
          if (_context.LeaveData == null)
          {
              return Problem("Entity set 'Attendance_Leave_Context.LeaveData'  is null.");
          }
            _context.LeaveData.Add(leaves);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaves", new { id = leaves.LeaveId }, leaves);
        }

        // DELETE: api/Leaves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaves(int id)
        {
            if (_context.LeaveData == null)
            {
                return NotFound();
            }
            var leaves = await _context.LeaveData.FindAsync(id);
            if (leaves == null)
            {
                return NotFound();
            }

            _context.LeaveData.Remove(leaves);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeavesExists(int id)
        {
            return (_context.LeaveData?.Any(e => e.LeaveId == id)).GetValueOrDefault();
        }
    }
}
