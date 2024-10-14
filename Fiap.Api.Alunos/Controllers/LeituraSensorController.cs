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
    [Route("api/leitura-sensor")]
    public class LeituraSensorController : ControllerBase
    {
        private readonly ILeituraSensorService _service;

        private readonly ISensorService _sensorService;

        private readonly IMapper _mapper;

        public LeituraSensorController(ILeituraSensorService leituraSensorService, ISensorService sensorService, IMapper mapper)
        {
            _service = leituraSensorService;
            _sensorService = sensorService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "admin, guest")]
        public ActionResult<IEnumerable<LeituraSensorPaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var leituras = _service.Listar(pagina, tamanho);
            var viewModelList = _mapper.Map<IEnumerable<LeituraSensorViewModel>>(leituras);

            var viewModel = new LeituraSensorPaginacaoViewModel
            {
                LeiturasSensor = viewModelList,
                CurrentPage = pagina,
                PageSize = tamanho
            };


            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin, guest")]
        public ActionResult<LeituraSensorViewModel> Get(int id)
        {
            var leitura = _service.ObterPorId(id);
            if (leitura == null)
                return NotFound();

            var viewModel = _mapper.Map<LeituraSensorViewModel>(leitura);
            return Ok(leitura);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Post([FromBody] CreateLeituraSensorViewModel viewModel)
        {
            var sensor = _sensorService.ObterPorId(viewModel.SensorId);
            if (sensor == null)
                return NotFound($"Não foi possível registrar a leitura, pois o sensor de id {viewModel.SensorId} não existe.");

            var leitura = _mapper.Map<LeituraSensorModel>(viewModel);
            _service.Criar(leitura);
            return CreatedAtAction(nameof(Get), new { id = leitura.LeituraSensorId }, leitura);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Put(int id, [FromBody] UpdateLeituraSensorViewModel viewModel)
        {
            var sensor = _sensorService.ObterPorId(viewModel.SensorId);
            if (sensor == null)
                return NotFound($"Não foi possível atualizar a leitura, pois o sensor de id {viewModel.SensorId} não existe.");

            var leitura = _service.ObterPorId(id);
            if (leitura == null)
                return NotFound();

            _mapper.Map(viewModel, leitura);
            _service.Atualizar(leitura);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var leitura = _service.ObterPorId(id);
            if (leitura == null)
                return NotFound();

            _service.Deletar(id);
            return NoContent();
        }
    }
}
