using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.ViewModel
{
    public class LeituraSensorViewModel
    {
        public int LeituraSensorId { get; set; }
        public float Valor { get; set; }
        public DateTime Horario { get; set; }
        public int SensorId { get; set; }
        public SensorViewModel Sensor { get; set; }
    }
}
