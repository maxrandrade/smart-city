using AutoMapper;
using Fiap.Web.Alunos.Controllers;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Fiap.Web.Alunos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Fiap.Api.Alunos.Testes
{
    public class IrrigacaoInteligenteControllerTest
    {
        private readonly IrrigacaoInteligenteController _controller;

        private readonly Mock<IIrrigacaoInteligenteService> _mockService;

        private readonly Mock<IAreaVerdeService> _mockAreaService;

        private readonly IMapper _mockMapper;
        public IrrigacaoInteligenteControllerTest()
        {
            _mockService = new Mock<IIrrigacaoInteligenteService>();

            _mockAreaService = new Mock<IAreaVerdeService>();

            _mockService.Setup(m => m.Listar()).Returns(new List<IrrigacaoInteligenteModel>
            {
                new IrrigacaoInteligenteModel { IrrigacaoId = 1, Horario = new DateTime(2024, 06, 21, 14, 30, 0), AreaVerdeId = 1 },
                new IrrigacaoInteligenteModel { IrrigacaoId = 2, Horario = new DateTime(2024, 06, 23, 14, 30, 0), AreaVerdeId = 1 }
            });

            _mockMapper = new AutoMapper.MapperConfiguration(c => {
                c.AllowNullCollections = true;
                c.AllowNullDestinationValues = true;
            }).CreateMapper();

            _controller = new IrrigacaoInteligenteController(_mockService.Object, _mockAreaService.Object, _mockMapper);
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
