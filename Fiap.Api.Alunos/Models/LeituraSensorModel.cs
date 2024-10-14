namespace Fiap.Web.Alunos.Models
{
    public class LeituraSensorModel
    {
        public int LeituraSensorId { get; set; }
        public float Valor { get; set; }
        public DateTime Horario { get; set; }
        public int SensorId { get; set; }
        public SensorModel Sensor { get; set; }
    }
}
