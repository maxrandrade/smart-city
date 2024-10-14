using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.ViewModel
{
    public class IrrigacaoInteligenteViewModel
    {
        public int IrrigacaoId { get; set; }
        public DateTime Horario { get; set; }
        public int AreaVerdeId { get; set; }
        public AreaVerdeViewModel AreaVerde { get; set; }
    }
}
