using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public interface ILeituraSensorService
    {
        IEnumerable<LeituraSensorModel> Listar();
        IEnumerable<LeituraSensorModel> Listar(int pagina = 0, int tamanho = 10);
        LeituraSensorModel ObterPorId(int id);
        void Criar(LeituraSensorModel sensor);
        void Atualizar(LeituraSensorModel sensor);
        void Deletar(int id);
    }

}
