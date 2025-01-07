using Contact.App.Core.Contact.UseCase.GetSingleContact;
using Infrastructure.Repository;

namespace Contact.App.Tests.Contact
{
    public class GetSingleContactUseTest
    {
        [Fact]
        public async Task GetUserById_ShouldReturnCorrectUser()
        {
            // Arrange
            var repository = new ContactRepository();
            var useCase = new GetSingleContact(repository);

            var contact = new Core.Contact.Entity.Contact { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123456789" };
            await repository.AddContactAsync(contact);

            // Act
            var fetchedUser = await useCase.GetContact(contact.Id);

            // Assert
            Assert.NotNull(fetchedUser);
            Assert.Equal(contact.FirstName, fetchedUser.FirstName);
            Assert.Equal(contact.LastName, fetchedUser.LastName);
            Assert.Equal(contact.Email, fetchedUser.Email);
            Assert.Equal(contact.PhoneNumber, fetchedUser.PhoneNumber);

        }
    }
}
