using ProgWebII.DTOs;

namespace ProgWebII.Servicos
{
    public interface IAutenticacaoServico
    {
        string? Login(MasterLoginDTO dto);
        string? Registro(MasterRegistroDTO dto);
    }
}
