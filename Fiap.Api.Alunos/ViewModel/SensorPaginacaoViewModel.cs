using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.ViewModel;

namespace Fiap.Api.Alunos.ViewModel
{
    public class SensorPaginacaoViewModel
    {

        public IEnumerable<SensorViewModel> Sensores { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Sensores.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Sensor?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/Sensor?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";



    }
}
