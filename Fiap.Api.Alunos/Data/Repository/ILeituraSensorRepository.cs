using Fiap.Web.Alunos.Models;
using System.Collections.Generic;

namespace Fiap.Web.Alunos.Data.Repository
{
    public interface ILeituraSensorRepository
    {
        IEnumerable<LeituraSensorModel> GetAll();
        IEnumerable<LeituraSensorModel> GetAll(int page, int size);

        LeituraSensorModel GetById(int id);
        void Add(LeituraSensorModel leitura);
        void Update(LeituraSensorModel leitura);
        void Delete(LeituraSensorModel leitura);
    }
}
