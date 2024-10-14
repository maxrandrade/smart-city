using Fiap.Web.Alunos.ViewModel;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Fiap.Api.Alunos.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace Fiap.Web.Alunos.Controllers
{
    [ApiController]
    [Route("api/irrigacao-inteligente")]
    public class IrrigacaoInteligenteController : ControllerBase
    {
        private readonly IIrrigacaoInteligenteService _service;

        private readonly IAreaVerdeService _areaService;

        private readonly IMapper _mapper;

        public IrrigacaoInteligenteController(IIrrigacaoInteligenteService irrigacaoInteligenteService, IAreaVerdeService areaService, IMapper mapper)
        {
            _service = irrigacaoInteligenteService;
            _areaService = areaService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "admin, guest")]
        public ActionResult<IEnumerable<IrrigacaoInteligentePaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var irrigacoes = _service.Listar(pagina, tamanho);
            var viewModelList = _mapper.Map<IEnumerable<IrrigacaoInteligenteViewModel>>(irrigacoes);

            var viewModel = new IrrigacaoInteligentePaginacaoViewModel
            {
                IrrigacoesInteligentes = viewModelList,
                CurrentPage = pagina,
                PageSize = tamanho
            };


            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin, guest")]
        public ActionResult<IrrigacaoInteligenteViewModel> Get(int id)
        {
            var irrigacao = _service.ObterPorId(id);
            if (irrigacao == null)
                return NotFound();

            var viewModel = _mapper.Map<IrrigacaoInteligenteViewModel>(irrigacao);
            return Ok(irrigacao);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Post([FromBody] CreateIrrigacaoInteligenteViewModel viewModel)
        {
            var area = _areaService.ObterPorId(viewModel.AreaVerdeId);
            if (area == null)
                return NotFound($"Não foi possível registrar a irrigação, pois a área de id {viewModel.AreaVerdeId} não existe.");
            
            var irrigacao = _mapper.Map<IrrigacaoInteligenteModel>(viewModel);
            _service.Criar(irrigacao);
            return CreatedAtAction(nameof(Get), new { id = irrigacao.IrrigacaoId }, irrigacao);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Put(int id, [FromBody] UpdateIrrigacaoInteligenteViewModel viewModel)
        {
            var area = _areaService.ObterPorId(viewModel.AreaVerdeId);
            if (area == null)
                return NotFound($"Não foi possível atualizar a irrigação, pois a área de id {viewModel.AreaVerdeId} não existe.");

            var irrigacao = _service.ObterPorId(id);
            if (irrigacao == null)
                return NotFound();

            _mapper.Map(viewModel, irrigacao);
            _service.Atualizar(irrigacao);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var irrigacao = _service.ObterPorId(id);
            if (irrigacao == null)
                return NotFound();

            _service.Deletar(id);
            return NoContent();
        }
    }
}
