using gestor_cestas_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gestor_cestas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILinkGenerator _linkGenerator;

        public BeneficiariosController(AppDbContext context, ILinkGenerator linkGenerator)
        {
            _context = context;
            _linkGenerator = linkGenerator; 
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Beneficiarios.ToListAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Beneficiario model)
        {
            _context.Beneficiarios.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Beneficiarios
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            if (_linkGenerator != null)
            {
                _linkGenerator.GerarLinks(model);
            }
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Beneficiario model)
        {
            if (id != model.Id) return BadRequest();
            var modeloDb = await _context.Beneficiarios.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();

            _context.Beneficiarios.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Beneficiarios.FindAsync(id);

            if (model == null) NotFound();

            if (model != null)
            {
                _context.Beneficiarios.Remove(model);
                await _context.SaveChangesAsync();

            }
            

            return NoContent();

        }

        private void GerarLinks(Beneficiario model)
        {
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "self", metodo: "GET"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "update", metodo: "PUT"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "delete", metodo: "Delete"));

        }

    }
}
