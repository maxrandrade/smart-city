using Fiap.Web.Alunos.Models;
using System.Collections.Generic;

namespace Fiap.Web.Alunos.Data.Repository
{
    public interface ISensorRepository
    {
        IEnumerable<SensorModel> GetAll();
        IEnumerable<SensorModel> GetAll(int page, int size);
        SensorModel GetById(int id);
        void Add(SensorModel sensor);
        void Update(SensorModel sensor);
        void Delete(SensorModel sensor);
    }
}
