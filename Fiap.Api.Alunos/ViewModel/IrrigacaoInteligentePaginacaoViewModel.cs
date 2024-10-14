using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.ViewModel;

namespace Fiap.Api.Alunos.ViewModel
{
    public class IrrigacaoInteligentePaginacaoViewModel
    {

        public IEnumerable<IrrigacaoInteligenteViewModel> IrrigacoesInteligentes { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => IrrigacoesInteligentes.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/IrrigacaoInteligente?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/IrrigacaoInteligente?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";



    }
}
