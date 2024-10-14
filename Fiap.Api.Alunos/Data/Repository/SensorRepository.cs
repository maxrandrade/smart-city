using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Alunos.Data.Repository
{
    public class SensorRepository : ISensorRepository
    {

        private readonly DatabaseContext _context;

        public SensorRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<SensorModel> GetAll() => _context.Sensores.ToList();

        public IEnumerable<SensorModel> GetAll(int page, int size)
        {
            return _context.Sensores
                            .Skip((page - 1) * page)
                            .Take(size)
                            .AsNoTracking()
                            .ToList();
        }

        public SensorModel GetById(int id) => _context.Sensores.Find(id);

        public void Add(SensorModel sensor)
        {
            _context.Sensores.Add(sensor);
            _context.SaveChanges();
        }

        public void Update(SensorModel sensor)
        {
            _context.Sensores.Update(sensor);
            _context.SaveChanges();
        }

        public void Delete(SensorModel sensor)
        {
            _context.Sensores.Remove(sensor);
            _context.SaveChanges();
        }
    }
}
