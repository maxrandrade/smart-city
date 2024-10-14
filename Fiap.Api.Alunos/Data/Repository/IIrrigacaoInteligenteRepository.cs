using Fiap.Web.Alunos.Models;
using System.Collections.Generic;

namespace Fiap.Web.Alunos.Data.Repository
{
    public interface IIrrigacaoInteligenteRepository
    {
        IEnumerable<IrrigacaoInteligenteModel> GetAll();
        IEnumerable<IrrigacaoInteligenteModel> GetAll(int page, int size);
        IrrigacaoInteligenteModel GetById(int id);
        void Add(IrrigacaoInteligenteModel leitura);
        void Update(IrrigacaoInteligenteModel leitura);
        void Delete(IrrigacaoInteligenteModel leitura);
    }
}
