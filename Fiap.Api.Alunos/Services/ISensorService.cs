using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public interface ISensorService
    {
        IEnumerable<SensorModel> Listar();
        IEnumerable<SensorModel> Listar(int pagina = 0, int tamanho = 10);
        SensorModel ObterPorId(int id);
        void Criar(SensorModel sensor);
        void Atualizar(SensorModel sensor);
        void Deletar(int id);
    }

}
