using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgWebII.DTOs;
using ProgWebII.Servicos;

namespace ProgWebII.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoServico _autenticacaoServico;

        public AutenticacaoController(IAutenticacaoServico autenticacaoServico)
        {
            _autenticacaoServico = autenticacaoServico;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioLoginDTO dto)
        {
            try
            {

                var token = _autenticacaoServico.Login(dto);
                if (token == null)
                    return Unauthorized();

                return Ok(new { token });
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("registro")]
        public IActionResult Registro([FromBody] UsuarioRegistroDTO dto)
        {
            // criar nova dto com telefone
            try
            {
                var token = _autenticacaoServico.Registro(dto);
                if (token == null)
                    return BadRequest();

                return StatusCode(201, new { token });
            }
            catch (ArgumentException e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
