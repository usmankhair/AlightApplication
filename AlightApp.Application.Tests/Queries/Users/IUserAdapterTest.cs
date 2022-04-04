using AlightApp.Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;
using AutoFixture;
using System.Linq;
using System.Threading.Tasks;
using AlightApp.Application.Queries.Users;
using System.Text;
using System.IO;

namespace AlightApp.Application.Tests.Queries.Users
{
    public class GetUserQueryHandlerTest : BaseTest
    {
        [Fact]
        public async Task Handle_GetWomenBelow25_ReturnsLessThan25()
        {
            // Arrange
            var mock = new Mock<IUserAdapter>();
            var cancellationToken = new CancellationToken();
            var fixture = new Fixture();
            var data = _Request.Where(m => m.Age < 25 && m.Gender == "female").ToList();  // To arrange the required collection

            mock.Setup(m => m.GetWomenBelow25(
                It.IsAny<List<Domain.User.User>>(),
                It.IsAny<CancellationToken>()
                )).ReturnsAsync(data);

            GetUserQueryHanlder hanlder = new GetUserQueryHanlder(mock.Object);

            // Act
            var actual = await hanlder.Handle(new GetUserQuery() { Users = _Request }, cancellationToken);

            // Assert
            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.True(actual.Max(m => m.Age) > 25);
        } 

        [Fact]
        public void Handle_GetWomenBelow25_ThrowException_NullReference()
        {
            // Arrange
            var mock = new Mock<IUserAdapter>();
            var cancellationToken = new CancellationToken();
            var fixture = new Fixture();

            mock.Setup(m => m.GetWomenBelow25(
                It.IsAny<List<Domain.User.User>>(),
                It.IsAny<CancellationToken>()
                ));

            GetUserQueryHanlder hanlder = new GetUserQueryHanlder(mock.Object);

            // Act
            Func<Task> action = () => hanlder.Handle(new GetUserQuery() { Users = _Request }, cancellationToken);

            // Assert
            var response = Assert.ThrowsAsync<NullReferenceException>(action);
            Assert.Equal(TaskStatus.Faulted, response.Status);
            Assert.True(null == response.Result);

        }
    }
}
