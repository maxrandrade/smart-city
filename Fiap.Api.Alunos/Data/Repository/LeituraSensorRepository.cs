namespace Fiap.Web.Alunos.Data.Repository
{
    using Fiap.Web.Alunos.Data.Contexts;
    using Fiap.Web.Alunos.Data.Repository;
    using Fiap.Web.Alunos.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class LeituraSensorRepository : ILeituraSensorRepository
    {
        private readonly DatabaseContext _context;

        public LeituraSensorRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<LeituraSensorModel> GetAll()
        {
            return _context.LeiturasSensor.Include(l => l.Sensor).ToList();
        }

        public IEnumerable<LeituraSensorModel> GetAll(int page, int size)
        {
            return _context.LeiturasSensor
                            .Include(l => l.Sensor)
                            .Skip((page - 1) * page)
                            .Take(size)
                            .AsNoTracking()
                            .ToList();
        }

        public LeituraSensorModel GetById(int id)
        {
            return _context.LeiturasSensor.Include(l => l.Sensor).FirstOrDefault(l => l.LeituraSensorId == id);
        }

        public void Add(LeituraSensorModel leitura)
        {
            _context.LeiturasSensor.Add(leitura);
            _context.SaveChanges();
        }

        public void Update(LeituraSensorModel leitura)
        {
            _context.Update(leitura);
            _context.SaveChanges();
        }

        public void Delete(LeituraSensorModel leitura)
        {
            _context.LeiturasSensor.Remove(leitura);
            _context.SaveChanges();
        }
    }

}
