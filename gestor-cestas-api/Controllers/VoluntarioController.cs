using gestor_cestas_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gestor_cestas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoluntarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILinkGenerator _linkGenerator;

        public VoluntarioController(AppDbContext context, ILinkGenerator linkGenerator)
        {
            _context = context;
            _linkGenerator = linkGenerator; 
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Voluntarios.ToListAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Voluntario model)
        {
            _context.Voluntarios.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Voluntarios
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            if (_linkGenerator != null)
            {
                _linkGenerator.GerarLinks(model);
            }
            return Ok(model);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Update(int id, Voluntario model)
        {
            if (id != model.Id) return BadRequest();
            var modeloDb = await _context.Voluntarios.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();

            _context.Voluntarios.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Voluntarios.FindAsync(id);

            if (model == null) NotFound();

            if (model != null)
            {
                _context.Voluntarios.Remove(model);
                await _context.SaveChangesAsync();
            }


            return NoContent();

        }

        private void GerarLinks(Voluntario model)
            {
                model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "self", metodo: "GET"));
                model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "update", metodo: "PUT"));
                model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "delete", metodo: "Delete"));

            }

        }
}
