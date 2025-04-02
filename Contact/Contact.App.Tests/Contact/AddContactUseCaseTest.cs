using Application.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.Entity;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Contact.App.Tests.Contact;

public class AddContactUseCaseTest
{
    [Fact]
    public async Task AddContact_Should_not_be_null()
    {
        // Arrange
        var repository = new ContactRepository();
        var addContactService = new AddContactUseCase(repository);
        var result = AddContactRequest.Create(
                id: Guid.NewGuid(),
                firstName: "",
                lastName: "Doumbouya",
                phoneNumber: "4844854565",
                email: "med@gmail.com"
            );
        // Act
        await addContactService.Execute(result);
        // Assert
        Assert.NotNull(result);
    }

   

    [Fact]
    public async Task AddContact_With_Invalid_Email_Should_Throw_Exception()
    {
        // Arrange
        var repository = new ContactRepository();
        var addContactService = new AddContactUseCase(repository);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() =>
            addContactService.Execute(AddContactRequest.Create(
                id: Guid.NewGuid(),
                 firstName: "Mohamed",
                lastName: "Doumbouya",
                phoneNumber: "4844854565",
                email: "med@gmail"
            ))
        );
    }

    [Fact]
    public async Task AddContact_With_Empty_FirstName_Should_Throw_Exception()
    {
        // Arrange
        var repository = new ContactRepository();
        var addContactService = new AddContactUseCase(repository);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() =>
            addContactService.Execute(AddContactRequest.Create(
                id: Guid.NewGuid(),
                 firstName: "Mohamed",
                lastName: "Doumbouya",
                phoneNumber: "4844854565",
                email: "med@gmail.com"
            ))
        );
    }

   
   
}