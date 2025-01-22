using Application.UseCase.AddContact;
using Application.UseCase.AddContact.Request;
using ContactApp.App.Core.Contact.Entity;
using ContactApp;
using Infrastructure.Repository;
using System;


namespace ContactApp.App.Tests.Contact
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
                id: new Guid(),
                firstName: "Mohamed",
                lastName: "Doumbouya",
                phoneNumber: "4844854565",
                email: "med@gmail.com"
                );

            // Act
            await useCase.Execute(request);

            // Assert
            var contacts = await repository.GetContactsAsync();
            var addedContact = contacts.FirstOrDefault();

            Assert.NotNull(addedContact); 
            Assert.Equal(request.FirstName, addedContact.GetFirsName()); 
            Assert.Equal(request.LastName, addedContact.GetLastName());
            Assert.Equal(request.Email, addedContact.GetEmail());
            Assert.Equal(request.PhoneNumber, addedContact.GetPhoneNumber());
        }

      
    }
}



