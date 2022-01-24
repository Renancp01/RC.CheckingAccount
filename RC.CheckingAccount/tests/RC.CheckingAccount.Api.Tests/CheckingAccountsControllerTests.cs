using System.Threading;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RC.CheckingAccount.Api.Controllers;
using RC.CheckingAccount.Domain.Commands.Client;
using RC.CheckingAccount.Domain.Entities;
using Xunit;

namespace RC.CheckingAccount.Api.Tests
{
    public class CheckingAccountsControllerTests
    {
        public Mock<IMediator> MediatorMock = new();

        [Fact]
        public void CheckingAccountsController_CreateClient_ReturnBadRequest()
        {
            //Arrange
            var input = new CreateClientCommand("Renan", "Carlos");

            var result = new Client("renan", string.Empty);

            MediatorMock.Setup(c => c.Send(It.IsAny<CreateClientCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(result);

            //Act
            var returns = new CheckingAccountsController(MediatorMock.Object).CreateClient(input);

            //Assert 
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(returns.Result);
        }

        [Fact]
        public void CheckingAccountsController_CreateClient_ReturnOK()
        {
            //Arrange
            var input = new CreateClientCommand("Renan", "Carlos");

            var result = new Client("Renan", "Carlos");

            MediatorMock.Setup(c => c.Send(It.IsAny<CreateClientCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(result);

            //Act
            var returns = new CheckingAccountsController(MediatorMock.Object).CreateClient(input);

            //Assert 
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(returns.Result);
        }

        [Fact]
        public void CheckingAccountsController_CreateClient_ReturnBadRequestWithNull()
        {
            //Arrange
            var input = new CreateClientCommand("Renan", "Carlos");

            MediatorMock.Setup(c => c.Send(It.IsAny<CreateClientCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(value:null);

            //Act
            var returns = new CheckingAccountsController(MediatorMock.Object).CreateClient(input);

            //Assert 
           
            Assert.IsType<BadRequestResult>(returns.Result);
        }
    }
}
