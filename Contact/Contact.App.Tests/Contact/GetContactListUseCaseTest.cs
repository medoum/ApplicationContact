

using Application.UseCase.ContactList;
using Infrastructure.Repository;

namespace Contact.App.Tests.Contact
{
    public class GetContactListUseCaseTest
    {
        [Fact]
        public async Task GetUser_ShouldReturnAllUsers()
        {
            // Arrange
            var repository = new ContactRepository();
            var useCase = new GetContactsUseCase(repository);

            var expectedUsers = new List<Core.Contact.Entity.Contact>
            {
               new Core.Contact.Entity.Contact {
                   FirstName =  "John",
                   LastName =  "Doe",
                   Email =  "john.doe@example.com",
                   PhoneNumber = "123456789",
                  
               },

            };

            foreach (var contact in expectedUsers)
            {
                await repository.AddContactAsync(contact);
            }

            // Act
            var contacts = await useCase.GetUserAsync();

            // Assert
            Assert.NotNull(contacts);
            Assert.Equal(expectedUsers.Count, contacts.Count);
            Assert.All(expectedUsers, expected =>
                Assert.Contains(contacts, actual => actual.Email == expected.Email));
        }

    }
}
