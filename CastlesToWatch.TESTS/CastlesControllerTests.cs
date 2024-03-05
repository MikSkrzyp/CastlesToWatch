using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using CastlesToWatch.API.Controllers;
using CastlesToWatch.API.Model.DTO;
using CastlesToWatch.API.Repositories;
using CastlesToWatch.API.Model.Domain;

namespace CastlesToWatch.TESTS
{
    internal class CastlesControllerTests
    {
        [Fact]
        public async Task GetAll_Returns_Ok_With_CastleDTOs()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var castleRepositoryMock = new Mock<ICastleRepository>();

            var expectedCastleDomain = new List<Castle>(); // Assuming Castle is your domain model
            var expectedCastleDTOs = new List<CastleDTO>(); // Assuming CastleDTO is your DTO model

            mapperMock
                .Setup(m => m.Map<List<CastleDTO>>(It.IsAny<List<Castle>>()))
                .Returns(expectedCastleDTOs);

            castleRepositoryMock
                .Setup(c => c.GetAllAsync(null, null, null, true))
                .ReturnsAsync(expectedCastleDomain);

            var controller = new CastlesController(mapperMock.Object, castleRepositoryMock.Object);

            // Act
            var result = await controller.GetAll(null, null, null, null) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var castleDTOs = result.Value as List<CastleDTO>;
            Assert.NotNull(castleDTOs);
            Assert.Equal(expectedCastleDTOs, castleDTOs);
        }
    }
}
