using AutoMapper;
using Fiap.Web.Alunos.Controllers;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Fiap.Web.Alunos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Fiap.Api.Alunos.Testes
{
    public class SensorControllerTest
    {
        private readonly SensorController _controller;

        private readonly Mock<ISensorService> _mockSensorService;

        private readonly IMapper _mockMapper;
        public SensorControllerTest()
        {
            _mockSensorService = new Mock<ISensorService>();

            _mockSensorService.Setup(m => m.Listar()).Returns(new List<SensorModel>
            {
                new SensorModel { SensorId = 1, Tipo = "Tipo 1", Localizacao = "Localizacao 1", Status = "Ativo" },
                new SensorModel { SensorId = 2, Tipo = "Tipo 2", Localizacao = "Localizacao 2", Status = "Ativo" }
            });

            _mockMapper = new AutoMapper.MapperConfiguration(c => {
                c.AllowNullCollections = true;
                c.AllowNullDestinationValues = true;
            }).CreateMapper();

            _controller = new SensorController(_mockSensorService.Object, _mockMapper);
        }

        [Fact]
        public async void Get_ReturnsHttpStatusCode200()
        {

            var response = _controller.Get(pagina: 1, tamanho: 10);

            Assert.IsType<OkObjectResult>(response.Result);

            var okResult = response.Result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
