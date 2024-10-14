using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public class LeituraSensorService : ILeituraSensorService
    {
        private readonly ILeituraSensorRepository _repository;

        public LeituraSensorService(ILeituraSensorRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<LeituraSensorModel> Listar() => _repository.GetAll();

        public IEnumerable<LeituraSensorModel> Listar(int pagina = 1, int tamanho = 10)
        {
            return _repository.GetAll(pagina, tamanho);
        }

        public LeituraSensorModel ObterPorId(int id) => _repository.GetById(id);

        public void Criar(LeituraSensorModel leitura) => _repository.Add(leitura);        

        public void Atualizar(LeituraSensorModel leitura) => _repository.Update(leitura);

        public void Deletar(int id)
        {
            var leitura = _repository.GetById(id);
            if (leitura != null)
            {
                _repository.Delete(leitura);
            }
        }

    }
}
