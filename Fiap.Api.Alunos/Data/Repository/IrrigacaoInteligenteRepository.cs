namespace Fiap.Web.Alunos.Data.Repository
{
    using Fiap.Web.Alunos.Data.Contexts;
    using Fiap.Web.Alunos.Data.Repository;
    using Fiap.Web.Alunos.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class IrrigacaoInteligenteRepository : IIrrigacaoInteligenteRepository
    {
        private readonly DatabaseContext _context;

        public IrrigacaoInteligenteRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<IrrigacaoInteligenteModel> GetAll()
        {
            return _context.IrrigacoesInteligentes
                .Include(i => i.AreaVerde)
                .ToList();
        }

        public IEnumerable<IrrigacaoInteligenteModel> GetAll(int page, int size)
        {
            return _context.IrrigacoesInteligentes
                            .Include(i => i.AreaVerde)
                            .Skip((page - 1) * page)
                            .Take(size)
                            .AsNoTracking()
                            .ToList();
        }

        public IrrigacaoInteligenteModel GetById(int id)
        {
            return _context.IrrigacoesInteligentes.Include(i => i.AreaVerde).FirstOrDefault(i => i.IrrigacaoId == id);
        }

        public void Add(IrrigacaoInteligenteModel irrigacao)
        {
            _context.IrrigacoesInteligentes.Add(irrigacao);
            _context.SaveChanges();
        }

        public void Update(IrrigacaoInteligenteModel irrigacao)
        {
            _context.Update(irrigacao);
            _context.SaveChanges();
        }

        public void Delete(IrrigacaoInteligenteModel irrigacao)
        {
            _context.IrrigacoesInteligentes.Remove(irrigacao);
            _context.SaveChanges();
        }
    }

}
