using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public class AreaVerdeService : IAreaVerdeService
    {
        private readonly IAreaVerdeRepository _repository;

        public AreaVerdeService(IAreaVerdeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<AreaVerdeModel> Listar() => _repository.GetAll();

        public IEnumerable<AreaVerdeModel> Listar(int pagina = 1, int tamanho = 10)
        {
            return _repository.GetAll(pagina, tamanho);
        }

        public AreaVerdeModel ObterPorId(int id) => _repository.GetById(id);

        public void Criar(AreaVerdeModel area) => _repository.Add(area);        

        public void Atualizar(AreaVerdeModel area) => _repository.Update(area);

        public void Deletar(int id)
        {
            var area = _repository.GetById(id);
            if (area != null)
            {
                _repository.Delete(area);
            }
        }

    }
}
