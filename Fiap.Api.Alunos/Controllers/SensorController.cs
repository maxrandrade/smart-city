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
    [Route("api/sensor")]
    public class SensorController : ControllerBase
    {
        private readonly ISensorService _service;

        private readonly IMapper _mapper;

        public SensorController(ISensorService sensorService, IMapper mapper)
        {
            _service = sensorService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "admin, guest")]
        public ActionResult<IEnumerable<SensorPaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var sensores = _service.Listar(pagina, tamanho);
            var viewModelList = _mapper.Map<IEnumerable<SensorViewModel>>(sensores);

            var viewModel = new SensorPaginacaoViewModel
            {
                Sensores = viewModelList,
                CurrentPage = pagina,
                PageSize = tamanho
            };


            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin, guest")]
        public ActionResult<SensorViewModel> Get(int id)
        {
            var sensor = _service.ObterPorId(id);
            if (sensor == null)
                return NotFound();

            var viewModel = _mapper.Map<SensorViewModel>(sensor);
            return Ok(sensor);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Post([FromBody] CreateSensorViewModel viewModel)
        {
            var sensor = _mapper.Map<SensorModel>(viewModel);
            _service.Criar(sensor);
            return CreatedAtAction(nameof(Get), new { id = sensor.SensorId }, sensor);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Put(int id, [FromBody] UpdateSensorViewModel viewModel)
        {
            var sensor = _service.ObterPorId(id);
            if (sensor == null)
                return NotFound();

            _mapper.Map(viewModel, sensor);
            _service.Atualizar(sensor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var sensor = _service.ObterPorId(id);
            if (sensor == null)
                return NotFound();

            _service.Deletar(id);
            return NoContent();
        }
    }
}
