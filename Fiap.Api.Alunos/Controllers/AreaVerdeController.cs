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
    [Route("api/area-verde")]
    public class AreaVerdeController : ControllerBase
    {
        private readonly IAreaVerdeService _service;

        private readonly IMapper _mapper;

        public AreaVerdeController(IAreaVerdeService areaVerdeService, IMapper mapper)
        {
            _service = areaVerdeService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "admin, guest")]
        public ActionResult<IEnumerable<AreaVerdePaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var areas = _service.Listar(pagina, tamanho);
            var viewModelList = _mapper.Map<IEnumerable<AreaVerdeViewModel>>(areas);

            var viewModel = new AreaVerdePaginacaoViewModel
            {
                AreasVerdes = viewModelList,
                CurrentPage = pagina,
                PageSize = tamanho
            };


            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin, guest")]
        public ActionResult<AreaVerdeViewModel> Get(int id)
        {
            var area = _service.ObterPorId(id);
            if (area == null)
                return NotFound();

            var viewModel = _mapper.Map<AreaVerdeViewModel>(area);
            return Ok(area);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Post([FromBody] CreateAreaVerdeViewModel viewModel)
        {
            var area = _mapper.Map<AreaVerdeModel>(viewModel);
            _service.Criar(area);
            return CreatedAtAction(nameof(Get), new { id = area.AreaVerdeId }, area);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Put(int id, [FromBody] UpdateAreaVerdeViewModel viewModel)
        {
            var area = _service.ObterPorId(id);
            if (area == null)
                return NotFound();

            _mapper.Map(viewModel, area);
            _service.Atualizar(area);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var area = _service.ObterPorId(id);
            if (area == null)
                return NotFound();

            _service.Deletar(id);
            return NoContent();
        }
    }
}
