using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgWebII.DTOs;
using ProgWebII.Servicos;

namespace ProgWebII.Controllers
{
    /// <summary>
    /// Controller de autenticação
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoServico _autenticacaoServico;

        public AutenticacaoController(IAutenticacaoServico autenticacaoServico)
        {
            _autenticacaoServico = autenticacaoServico;
        }

        /// <summary>
        /// Método para fazer login
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna o token de autenticação</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] MasterLoginDTO dto)
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

        /// <summary>
        /// Método para criar usuário de autenticação
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna o token de autenticação</returns>
        [HttpPost("registro")]
        public IActionResult Registro([FromBody] MasterRegistroDTO dto)
        {
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
