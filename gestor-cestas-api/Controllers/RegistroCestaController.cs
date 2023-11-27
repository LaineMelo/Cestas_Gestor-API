using gestor_cestas_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gestor_cestas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroCestaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegistroCestaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.RegistroCestas.ToListAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RegistroCesta model)
        {
            _context.RegistroCestas.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.RegistroCestas
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            return Ok(model);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Update(int id, RegistroCesta model)
        {
            if (id != model.Id) return BadRequest();
            var modeloDb = await _context.RegistroCestas.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();

            _context.RegistroCestas.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.RegistroCestas.FindAsync(id);

            if (model == null) NotFound();

            if (model != null)
            {
                _context.RegistroCestas.Remove(model);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        [HttpGet("/lista-beneficiario/{idBeneficiario}")]
        public async Task<ActionResult> GetByIdBeneficiario(int idBeneficiario)
        {
            var model = await _context.RegistroCestas
                .Where(c => c.IdBeneficiario == idBeneficiario)
                .ToListAsync();

            if (model == null) return NotFound();

            return Ok(model);
        }

        [HttpGet("/lista-voluntario/{idVoluntario}")]
        public async Task<ActionResult> GetByIdVoluntario(int idVoluntario)
        {
            var model = await _context.RegistroCestas
                .Where(c => c.IdVoluntario == idVoluntario)
                .ToListAsync();

            if (model == null) return NotFound();

            return Ok(model);
        }

    }
}
