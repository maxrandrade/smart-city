using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public interface IIrrigacaoInteligenteService
    {
        IEnumerable<IrrigacaoInteligenteModel> Listar();
        IEnumerable<IrrigacaoInteligenteModel> Listar(int pagina = 0, int tamanho = 10);
        IrrigacaoInteligenteModel ObterPorId(int id);
        void Criar(IrrigacaoInteligenteModel irrigacao);
        void Atualizar(IrrigacaoInteligenteModel irrigacao);
        void Deletar(int id);
    }

}
