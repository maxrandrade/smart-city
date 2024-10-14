using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public interface IAreaVerdeService
    {
        IEnumerable<AreaVerdeModel> Listar();
        IEnumerable<AreaVerdeModel> Listar(int pagina = 0, int tamanho = 10);
        AreaVerdeModel ObterPorId(int id);
        void Criar(AreaVerdeModel sensor);
        void Atualizar(AreaVerdeModel sensor);
        void Deletar(int id);
    }

}
