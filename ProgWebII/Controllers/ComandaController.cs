using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgWebII.DTOs;
using ProgWebII.Modelos;
using ProgWebII.Servicos;

namespace ProgWebII.Controllers
{
    /// <summary>
    /// Controller de comandas
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("RestAPIFurb/comandas")]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaServico _comandaServico;

        public ComandaController(IComandaServico comandaServico)
        {
            _comandaServico = comandaServico;
        }

        /// <summary>
        /// Busca todas as comandas
        /// </summary>
        /// <returns>Retorna a lista de comandas</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _comandaServico.ObterComandasSimples();
            if (!result.Any())
                return NoContent();

            var retorno = result.Select(sel => new GetComandaSimplesDTO()
            {
                UsuarioId = sel.UsuarioId,
                UsuarioNome = sel.Usuario?.Nome,
                UsuarioTelefone = sel.Usuario?.Telefone
            });

            return Ok(retorno);
        }

        /// <summary>
        /// Busca a comanda pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna a comanda encontrada, caso exista</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _comandaServico.ObterComProdutos(id);
            if (result == null)
                return NotFound();

            var retorno = new GetComandaDTO()
            {
                Produtos = result.ProdutosComanda.Select(select => new ProdutoDTO()
                {
                    Id = select.ProdutoId,
                    Nome = select.Produto?.Nome,
                    Preco = select.Produto?.Preco
                }).ToList(),
                UsuarioId = result.UsuarioId,
                UsuarioNome = result.Usuario?.Nome,
                UsuarioTelefone = result.Usuario?.Telefone
            };
            return Ok(retorno);
        }

        /// <summary>
        /// Cria uma nova comanda
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna o objeto da comanda junto com o id</returns>
        [HttpPost]
        public IActionResult Create(CriarComandaRequestDTO dto)
        {
            var entidade = new Comanda()
            {
                ProdutosComanda = dto.Produtos.Select(select => new ProdutoComanda()
                {
                    ProdutoId = select.Id ?? 0,
                    Produto = select.Id == null || select.Id == 0 ? new Produto()
                    {
                        Id = select.Id ?? 0,
                        Nome = select.Nome ?? "",
                        Preco = select.Preco ?? 0
                    } : null
                }).ToList(),
                UsuarioId = dto.UsuarioId ?? 0,
                Usuario = dto.UsuarioId == 0 ? new Usuario()
                {
                    Id = dto.UsuarioId ?? 0,
                    Nome = dto.UsuarioNome ?? "",
                    Telefone = dto.UsuarioTelefone ?? ""
                } : null
            };
            try
            {
                entidade.ProdutosComanda.Select(sel => sel.Produto).ToList().ForEach(foreachItem => foreachItem?.Validar());
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            _comandaServico.Inserir(entidade);

            CriarComandaRespostaDTO result = new CriarComandaRespostaDTO
            {
                Id = entidade.Id,
                Produtos = entidade.ProdutosComanda.Select(sel => new ProdutoDTO()
                {
                    Id = sel.ProdutoId,
                    Nome = sel.Produto?.Nome,
                    Preco = sel.Produto?.Preco
                }).ToList(),
                UsuarioId = entidade.UsuarioId,
                UsuarioNome = dto.UsuarioNome,
                UsuarioTelefone = dto.UsuarioTelefone
            };

            return Ok(result);
        }

        /// <summary>
        /// Altera uma comanda existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, AlterarComandaRequestDTO dto)
        {
            _comandaServico.AlterarProdutos(id, dto);
            return Ok(new RetornoSucessoDTO("comanda alterada"));
        }

        /// <summary>
        /// Deleta uma comanda existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna uma mensagem de sucesso na deleção</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entidade = _comandaServico.ObterPorId(id);
            if (entidade == null)
                return NotFound();

            _comandaServico.Deletar(entidade);
            return Ok(new RetornoSucessoDTO("comanda removida"));
        }
    }
}
