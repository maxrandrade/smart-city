using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _repository;

        public SensorService(ISensorRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<SensorModel> Listar() => _repository.GetAll();

        public IEnumerable<SensorModel> Listar(int pagina = 1, int tamanho = 10)
        {
            return _repository.GetAll(pagina, tamanho);
        }

        public SensorModel ObterPorId(int id) => _repository.GetById(id);

        public void Criar(SensorModel sensor) => _repository.Add(sensor);        

        public void Atualizar(SensorModel sensor) => _repository.Update(sensor);

        public void Deletar(int id)
        {
            var sensor = _repository.GetById(id);
            if (sensor != null)
            {
                _repository.Delete(sensor);
            }
        }

    }
}
