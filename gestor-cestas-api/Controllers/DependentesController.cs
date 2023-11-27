using gestor_cestas_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gestor_cestas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DependentesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Dependentes.ToListAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Dependente model)
        {
            _context.Dependentes.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Dependentes
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            return Ok(model);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Update(int id, Dependente model)
        {
            if (id != model.Id) return BadRequest();
            var modeloDb = await _context.Dependentes.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();

            _context.Dependentes.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Dependentes.FindAsync(id);

            if (model == null) NotFound();

            if (model != null)
            {
                _context.Dependentes.Remove(model);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        [HttpGet("/beneficiario/{idBeneficiario}")]
        public async Task<ActionResult> GetByIdBeneficiario(int idBeneficiario)
        {
            var model = await _context.Dependentes
                .Where(c => c.IdBeneficiario == idBeneficiario)
                .ToListAsync();

            if (model == null) return NotFound();

            return Ok(model);
        }

    }
}
