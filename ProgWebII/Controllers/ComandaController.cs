using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgWebII.Servicos;

namespace ProgWebII.Controllers
{
    [ApiController]
    [Authorize]
    [Route("comandas")]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaServico _comandaServico;

        public ComandaController(IComandaServico comandaServico)
        {
            _comandaServico = comandaServico;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _comandaServico.ObterTodos();
            if (result.Any())
                return Ok(result);

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _comandaServico.ObterPorId(id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
