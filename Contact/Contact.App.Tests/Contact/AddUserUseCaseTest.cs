using Application.UseCase.AddContact;
using Application.UseCase.AddContact.Request;
using Contact.App.Core.Contact.Entities;
using Contact.App.Core.Contact.Repository;
using Moq;

namespace Contact.App.Tests.Contact
{
    public class AddContactUseCaseTest
    {
        [Fact]
        public async Task AddContact_ShouldCallAddUserAsync_WithCorrectUser()
        {
            // Arrange
            var mockRepo = new Mock<IContactRepository>();
            var useCase = new AddContactUseCase(mockRepo.Object);

            var request = new AddContactRequest
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "123456789",
               
            };

            ContactDto expectedUser = ContactFactory.CreateContact(
                request.FirstName,
                request.LastName,
                request.Email,
                request.PhoneNumber
               
            );

            // Act
            await useCase.AddContact(request);

            // Assert
            mockRepo.Verify(repo => repo.AddContactAsync(
                It.Is<ContactDto>(contact =>
                    contact.FirstName == request.FirstName &&
                    contact.LastName == request.LastName &&
                    contact.Email == request.Email &&
                    contact.PhoneNumber == request.PhoneNumber
                )
            ), Times.Once);
        }

    }
}
