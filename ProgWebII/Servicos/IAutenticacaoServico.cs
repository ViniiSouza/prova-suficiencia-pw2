using ProgWebII.DTOs;

namespace ProgWebII.Servicos
{
    public interface IAutenticacaoServico
    {
        string? Login(UsuarioLoginDTO dto);
        string? Registro(UsuarioRegistroDTO dto);
    }
}
