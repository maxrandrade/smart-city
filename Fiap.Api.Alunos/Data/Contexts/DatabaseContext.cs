using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Alunos.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<SensorModel> Sensores { get; set; }
        public virtual DbSet<AreaVerdeModel> AreasVerdes { get; set; }
        public virtual DbSet<LeituraSensorModel> LeiturasSensor { get; set; }
        public virtual DbSet<IrrigacaoInteligenteModel> IrrigacoesInteligentes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SensorModel>(entity =>
            {
                entity.ToTable("Sensor");
                entity.HasKey(s => s.SensorId);
                entity.Property(s => s.Tipo).IsRequired();
                entity.Property(s => s.Localizacao).IsRequired();
                entity.Property(s => s.Status).IsRequired();
            });

            modelBuilder.Entity<AreaVerdeModel>(entity =>
            {
                entity.ToTable("AreaVerde");
                entity.HasKey(a => a.AreaVerdeId);
                entity.Property(a => a.Nome).IsRequired();
                entity.Property(a => a.Localizacao).IsRequired();
                entity.Property(a => a.Tamanho).HasColumnType("NUMBER(9,2)").IsRequired();
            });

            modelBuilder.Entity<LeituraSensorModel>(entity =>
            {
                entity.ToTable("LeituraSensor");
                entity.HasKey(l => l.LeituraSensorId);
                entity.Property(l => l.Valor).HasColumnType("NUMBER(9,2)").IsRequired();
                entity.Property(l => l.Horario).HasColumnType("date").IsRequired();
                entity.HasOne(l => l.Sensor)
                    .WithMany()
                    .HasForeignKey(l => l.SensorId)
                    .IsRequired();
            });

            modelBuilder.Entity<IrrigacaoInteligenteModel>(entity =>
            {
                entity.ToTable("IrrigacaoInteligente");
                entity.HasKey(i => i.IrrigacaoId);
                entity.Property(i => i.Horario).HasColumnType("date").IsRequired();
                entity.HasOne(i => i.AreaVerde)
                    .WithMany()
                    .HasForeignKey(i => i.AreaVerdeId)
                    .IsRequired();
            });

        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }
    }
}
