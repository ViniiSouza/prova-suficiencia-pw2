using ProgWebII.Auxiliares;
using ProgWebII.DTOs;
using ProgWebII.Repositorios;
using ProgWebII.Seguranca;
using System.Security.Cryptography;
using System.Text;

namespace ProgWebII.Servicos
{
    public class AutenticacaoServico : IAutenticacaoServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AutenticacaoServico(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public string? Login(UsuarioLoginDTO dto)
        {
            dto.Senha = ToShaHash(dto.Senha);
            var entidade = _usuarioRepositorio.ObterPorNome(dto.Nome);

            if (entidade == null)
                throw new System.ArgumentException("Usuário não encontrado");

            if (!_usuarioRepositorio.UsuarioValido(dto.Nome, dto.Senha))
                throw new System.ArgumentException("Senha inválida");

            return TokenServico.GerarToken(entidade);
        }

        public string? Registro(UsuarioRegistroDTO dto)
        {
            if (_usuarioRepositorio.ObterPorNome(dto.Nome) != null)
            {
                throw new ArgumentException("Usuário já existe");
            }

            dto.Senha = ToShaHash(dto.Senha);
            if (_usuarioRepositorio.UsuarioValido(dto.Nome, dto.Senha))
                return null;

            var entidade = new Modelos.Usuario
            {
                Nome = dto.Nome,
                Senha = dto.Senha,
                Telefone = dto.Telefone
            };

            _usuarioRepositorio.Inserir(entidade);
            _usuarioRepositorio.Salvar();

            return TokenServico.GerarToken(entidade);
        }

        private static string ToShaHash(string str)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(str));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
