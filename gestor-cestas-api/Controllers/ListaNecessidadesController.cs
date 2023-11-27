using gestor_cestas_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gestor_cestas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaNecessidadesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ListaNecessidadesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.ListaNecessidades.ToListAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ListaNecessidade model)
        {
            _context.ListaNecessidades.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.ListaNecessidades
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            return Ok(model);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Update(int id, ListaNecessidade model)
        {
            if (id != model.Id) return BadRequest();
            var modeloDb = await _context.ListaNecessidades.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();

            _context.ListaNecessidades.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.ListaNecessidades.FindAsync(id);

            if (model == null) NotFound();

            if (model != null)
            {
                _context.ListaNecessidades.Remove(model);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        [HttpGet("/lista-necessidade/{idBeneficiario}")]
        public async Task<ActionResult> GetByIdBeneficiario(int idBeneficiario)
        {
            var model = await _context.ListaNecessidades
                .Where(l => l.IdBeneficiario == idBeneficiario)
                .ToListAsync();

            if (model == null) return NotFound();

            return Ok(model);
        }

    }
}
