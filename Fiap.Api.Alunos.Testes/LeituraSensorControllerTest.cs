using AutoMapper;
using Fiap.Web.Alunos.Controllers;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Fiap.Web.Alunos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Fiap.Api.Alunos.Testes
{
    public class LeituraSensorControllerTest
    {
        private readonly LeituraSensorController _controller;

        private readonly Mock<ILeituraSensorService> _mockService;

        private readonly Mock<ISensorService> _mockSensorService;

        private readonly IMapper _mockMapper;
        public LeituraSensorControllerTest()
        {
            _mockService = new Mock<ILeituraSensorService>();

            _mockSensorService = new Mock<ISensorService>();

            _mockService.Setup(m => m.Listar()).Returns(new List<LeituraSensorModel>
            {
                new LeituraSensorModel { LeituraSensorId = 1, Valor = 500, Horario = new DateTime(2024, 06, 21, 14, 30, 0), SensorId = 1 },
                new LeituraSensorModel { LeituraSensorId = 2, Valor = 700, Horario = new DateTime(2024, 06, 23, 14, 30, 0), SensorId = 1 }
            });

            _mockMapper = new AutoMapper.MapperConfiguration(c => {
                c.AllowNullCollections = true;
                c.AllowNullDestinationValues = true;
            }).CreateMapper();

            _controller = new LeituraSensorController(_mockService.Object, _mockSensorService.Object, _mockMapper);
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
