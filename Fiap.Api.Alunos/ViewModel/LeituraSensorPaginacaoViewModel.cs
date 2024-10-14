using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.ViewModel;

namespace Fiap.Api.Alunos.ViewModel
{
    public class LeituraSensorPaginacaoViewModel
    {

        public IEnumerable<LeituraSensorViewModel> LeiturasSensor { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => LeiturasSensor.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/LeituraSensor?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/LeituraSensor?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";



    }
}
