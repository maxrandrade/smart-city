using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public class IrrigacaoInteligenteService : IIrrigacaoInteligenteService
    {
        private readonly IIrrigacaoInteligenteRepository _repository;

        public IrrigacaoInteligenteService(IIrrigacaoInteligenteRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<IrrigacaoInteligenteModel> Listar() => _repository.GetAll();

        public IEnumerable<IrrigacaoInteligenteModel> Listar(int pagina = 1, int tamanho = 10)
        {
            return _repository.GetAll(pagina, tamanho);
        }
        public IrrigacaoInteligenteModel ObterPorId(int id) => _repository.GetById(id);

        public void Criar(IrrigacaoInteligenteModel irrigacao) => _repository.Add(irrigacao);

        public void Atualizar(IrrigacaoInteligenteModel irrigacao) => _repository.Update(irrigacao);

        public void Deletar(int id)
        {
            var irrigacao = _repository.GetById(id);
            if (irrigacao != null)
            {
                _repository.Delete(irrigacao);
            }
        }

    }
}
