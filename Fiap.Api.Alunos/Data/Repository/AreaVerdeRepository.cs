using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Alunos.Data.Repository
{
    public class AreaVerdeRepository : IAreaVerdeRepository
    {

        private readonly DatabaseContext _context;

        public AreaVerdeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<AreaVerdeModel> GetAll() => _context.AreasVerdes.ToList();

        public IEnumerable<AreaVerdeModel> GetAll(int page, int size)
        {
            return _context.AreasVerdes
                            .Skip((page - 1) * page)
                            .Take(size)
                            .AsNoTracking()
                            .ToList();
        }
        public AreaVerdeModel GetById(int id) => _context.AreasVerdes.Find(id);

        public void Add(AreaVerdeModel area)
        {
            _context.AreasVerdes.Add(area);
            _context.SaveChanges();
        }

        public void Update(AreaVerdeModel area)
        {
            _context.AreasVerdes.Update(area);
            _context.SaveChanges();
        }

        public void Delete(AreaVerdeModel area)
        {
            _context.AreasVerdes.Remove(area);
            _context.SaveChanges();
        }
    }
}
