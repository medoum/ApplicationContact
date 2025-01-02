using Application.UseCase.ContactList;
using Contact.App.Core.Contact.Entities;
using Contact.App.Core.Contact.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.App.Tests.Contact
{
    public class GetListUseCaseTest
    {
        [Fact]
        public async Task GetUserList_ShouldReturnCorrectUserList()
        {
            // Arrange
            var expectedUsers = new List<ContactDto>
        {
            new ContactDto
            {
                FirstName = "Med",
                LastName = "D",
                Email = "test@gmail.com",
                PhoneNumber = "123456789",
               
            },
            new ContactDto
            {
                FirstName = "Cam",
                LastName = "Dia",
                Email = "cam@gmail.com",
                PhoneNumber = "987654321",
               
            }
        };

            var mockUserRepository = new Mock<IContactRepository>();
            mockUserRepository
                .Setup(repo => repo.GetContactsAsync())
                .ReturnsAsync(expectedUsers);

            var useCase = new GetContactsUseCase(mockUserRepository.Object);

            // Act
            var actualUsers = await useCase.GetUserAsync();

            // Assert
            Assert.Equal(expectedUsers.Count, actualUsers.Count);

            for (int i = 0; i < expectedUsers.Count; i++)
            {
                Assert.Equal(expectedUsers[i].FirstName, actualUsers[i].FirstName);
                Assert.Equal(expectedUsers[i].LastName, actualUsers[i].LastName);
                Assert.Equal(expectedUsers[i].Email, actualUsers[i].Email);
                Assert.Equal(expectedUsers[i].PhoneNumber, actualUsers[i].PhoneNumber);
            
            }

            mockUserRepository.Verify(repo => repo.GetContactsAsync(), Times.Once);
        }
    }
}

