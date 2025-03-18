using Application.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.Entity;

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
                firstName: "Mohamed",
                lastName: "Doumbouya",
                phoneNumber: "4844854565",
                email: "med@gmail.com"
            );

        // Act
        await addContactService.Execute(result);

        // Assert
        Assert.NotNull(result);


    }



}

