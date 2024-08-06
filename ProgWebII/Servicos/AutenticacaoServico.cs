using ProgWebII.Auxiliares;
using ProgWebII.DTOs;
using ProgWebII.Modelos;
using ProgWebII.Repositorios;
using ProgWebII.Seguranca;
using System.Security.Cryptography;
using System.Text;

namespace ProgWebII.Servicos
{
    public class AutenticacaoServico : IAutenticacaoServico
    {
        private readonly IMasterRepositorio _masterRepositorio;

        public AutenticacaoServico(IMasterRepositorio usuarioRepositorio)
        {
            _masterRepositorio = usuarioRepositorio;
        }

        public string? Login(MasterLoginDTO dto)
        {
            dto.Senha = ToShaHash(dto.Senha);
            var entidade = _masterRepositorio.ObterPorLogin(dto.Nome);

            if (entidade == null)
                throw new System.ArgumentException("Usuário não encontrado");

            if (!_masterRepositorio.MasterValido(dto.Nome, dto.Senha))
                throw new System.ArgumentException("Senha inválida");

            return TokenServico.GerarToken(entidade);
        }

        public string? Registro(MasterRegistroDTO dto)
        {
            if (_masterRepositorio.ObterPorLogin(dto.Nome) != null)
            {
                throw new ArgumentException("Usuário já existe");
            }

            dto.Senha = ToShaHash(dto.Senha);
            if (_masterRepositorio.MasterValido(dto.Nome, dto.Senha))
                return null;

            var entidade = new Master
            {
                Login = dto.Nome,
                Senha = dto.Senha
            };

            _masterRepositorio.Inserir(entidade);
            _masterRepositorio.Salvar();

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
