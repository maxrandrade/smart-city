using Fiap.Web.Alunos.Models;
using System.Collections.Generic;

namespace Fiap.Web.Alunos.Data.Repository
{
    public interface IAreaVerdeRepository
    {
        IEnumerable<AreaVerdeModel> GetAll();
        IEnumerable<AreaVerdeModel> GetAll(int page, int size);
        AreaVerdeModel GetById(int id);
        void Add(AreaVerdeModel area);
        void Update(AreaVerdeModel area);
        void Delete(AreaVerdeModel area);
    }
}
