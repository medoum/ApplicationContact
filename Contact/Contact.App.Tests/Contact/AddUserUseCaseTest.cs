using Application.UseCase.AddContact;
using Application.UseCase.AddContact.Request;
using Infrastructure.Repository;


namespace Contact.App.Tests.Contact
{
    public class AddContactUseCaseTest
    {
        [Fact]
        public async Task AddContact_ShouldCallAddUserAsync_WithCorrectUser()
        {
            // Arrange
            var repository = new ContactRepository();
            var useCase = new AddContactUseCase(repository);

            var request = AddContactRequest.Create(
                firstName: "Mohamed",
                lastName: "Doumbouya",
                phoneNumber: "4844854565",
                email: "med@gmail.com"
                );

            // Act
            await useCase.AddContact(request);

            // Assert
            var contacts = await repository.GetContactsAsync();
            var addedContact = contacts.FirstOrDefault();

            Assert.NotNull(addedContact); 
            Assert.Equal(request.FirstName, addedContact.FirstName); 
            Assert.Equal(request.LastName, addedContact.LastName);
            Assert.Equal(request.Email, addedContact.Email);
            Assert.Equal(request.PhoneNumber, addedContact.PhoneNumber);
        }

    }
}
