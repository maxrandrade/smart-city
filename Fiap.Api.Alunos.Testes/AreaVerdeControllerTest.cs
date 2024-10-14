using AutoMapper;
using Fiap.Web.Alunos.Controllers;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Fiap.Web.Alunos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Fiap.Api.Alunos.Testes
{
    public class AreaVerdeControllerTest
    {
        private readonly AreaVerdeController _controller;

        private readonly Mock<IAreaVerdeService> _mockService;

        private readonly IMapper _mockMapper;
        public AreaVerdeControllerTest()
        {
            _mockService = new Mock<IAreaVerdeService>();

            _mockService.Setup(m => m.Listar()).Returns(new List<AreaVerdeModel>
            {
                new AreaVerdeModel { AreaVerdeId = 1, Nome = "Area Verde 1", Localizacao = "Localizacao 1", Tamanho = 600 },
                new AreaVerdeModel { AreaVerdeId = 2, Nome = "Area Verde 2", Localizacao = "Localizacao 2", Tamanho = 900 }
            });

            _mockMapper = new AutoMapper.MapperConfiguration(c => {
                c.AllowNullCollections = true;
                c.AllowNullDestinationValues = true;
            }).CreateMapper();

            _controller = new AreaVerdeController(_mockService.Object, _mockMapper);
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
