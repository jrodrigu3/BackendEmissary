using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.models;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionesController : ControllerBase
    {
        private readonly APIContext _context;

        public DireccionesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Direcciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Direcciones>>> GetDirecciones()
        {
            return await _context.Direcciones.ToListAsync();
        }

        // GET: api/Direcciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Direcciones>> GetDirecciones(int id)
        {
            var direcciones = await _context.Direcciones.FindAsync(id);

            if (direcciones == null)
            {
                return NotFound();
            }

            return direcciones;
        }

        // PUT: api/Direcciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirecciones(int id, Direcciones direcciones)
        {
            if (id != direcciones.Id)
            {
                return BadRequest();
            }

            _context.Entry(direcciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DireccionesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDirecciones", new { id = direcciones.Id }, direcciones);
        }

        // POST: api/Direcciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Direcciones>> PostDirecciones(Direcciones direcciones)
        {
            _context.Direcciones.Add(direcciones);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetDirecciones", new { id = direcciones.Id }, direcciones);
        }

        // DELETE: api/Direcciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Direcciones>> DeleteDirecciones(int id)
        {
            var direcciones = await _context.Direcciones.FindAsync(id);
            if (direcciones == null)
            {
                return NotFound();
            }

            _context.Direcciones.Remove(direcciones);
            await _context.SaveChangesAsync();

            return direcciones;
        }

        private bool DireccionesExists(int id)
        {
            return _context.Direcciones.Any(e => e.Id == id);
        }
    }
}
