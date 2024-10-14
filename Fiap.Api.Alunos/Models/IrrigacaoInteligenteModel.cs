namespace Fiap.Web.Alunos.Models
{
    public class IrrigacaoInteligenteModel
    {
        public int IrrigacaoId { get; set; }
        public DateTime Horario { get; set; }
        public int AreaVerdeId { get; set; }
        public AreaVerdeModel AreaVerde { get; set; }
    }
}
