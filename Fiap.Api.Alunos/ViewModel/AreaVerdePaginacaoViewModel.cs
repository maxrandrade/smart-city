using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.ViewModel;

namespace Fiap.Api.Alunos.ViewModel
{
    public class AreaVerdePaginacaoViewModel
    {

        public IEnumerable<AreaVerdeViewModel> AreasVerdes { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => AreasVerdes.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/AreaVerde?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/AreaVerde?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";



    }
}
