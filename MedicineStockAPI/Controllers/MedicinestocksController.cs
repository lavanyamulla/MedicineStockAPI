using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicineStockAPI;
using Microsoft.AspNetCore.Cors;

namespace MedicineStockAPI.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinestocksController : ControllerBase
    {
        private readonly pharmacydbContext _context;

        public MedicinestocksController(pharmacydbContext context)
        {
            _context = context;
        }

        // GET: api/Medicinestocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicinestock>>> GetMedicinestocks()
        {
          if (_context.Medicinestocks == null)
          {
              return NotFound();
          }
            return await _context.Medicinestocks.ToListAsync();
        }

        // GET: api/Medicinestocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicinestock>> GetMedicinestock(int id)
        {
          if (_context.Medicinestocks == null)
          {
              return NotFound();
          }
            var medicinestock = await _context.Medicinestocks.FindAsync(id);

            if (medicinestock == null)
            {
                return NotFound();
            }

            return medicinestock;
        }

        // PUT: api/Medicinestocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicinestock(int id, Medicinestock medicinestock)
        {
            if (id != medicinestock.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicinestock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicinestockExists(id))
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

        // POST: api/Medicinestocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medicinestock>> PostMedicinestock(Medicinestock medicinestock)
        {
          if (_context.Medicinestocks == null)
          {
              return Problem("Entity set 'pharmacydbContext.Medicinestocks'  is null.");
          }
            _context.Medicinestocks.Add(medicinestock);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicinestockExists(medicinestock.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedicinestock", new { id = medicinestock.Id }, medicinestock);
        }

        // DELETE: api/Medicinestocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicinestock(int id)
        {
            if (_context.Medicinestocks == null)
            {
                return NotFound();
            }
            var medicinestock = await _context.Medicinestocks.FindAsync(id);
            if (medicinestock == null)
            {
                return NotFound();
            }

            _context.Medicinestocks.Remove(medicinestock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicinestockExists(int id)
        {
            return (_context.Medicinestocks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
