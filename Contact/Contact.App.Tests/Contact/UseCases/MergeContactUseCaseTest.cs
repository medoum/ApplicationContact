using Application.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.UseCase.AddContactGroup;
using Contact.App.Core.ContactApp.UseCase.AddContactToGroup;
using Contact.App.Core.ContactApp.UseCase.MergeContact;
using Infrastructure.Repository;

namespace Contact.App.Tests.Contact.UseCases
{
    //public class MergeContactUseCaseTest
    //{
    //    [Fact]
    //    //public async Task MergeContactUseCase_ShouldReturnExistingContactId_WhenContactExists()
    //    //
    //    //    // Arrange
    //    //    var repository = new ContactRepository();
    //    //    var repositoryGroup = new ContactGroupRepository();
    //    //    var addContactToGroupUseCase = new AddContactToGroupUseCase(repositoryGroup, repository);
    //    //    var addContactUseCase = new AddContactUseCase(repository, addContactToGroupUseCase);
    //    //    var mergeUseCase = new MergeContactUseCase(repository, addContactToGroupUseCase);


    //    //    Guid GroupId = Guid.NewGuid();
    //    //    // Act
    //    //    var existingRequest = AddContactRequest.Create(GroupId,"Med", "Doumb", "8575858", "med@gmail.com");
    //    //    var existingContactId = await addContactUseCase.Execute(existingRequest);
    //    //    Guid ContactId = Guid.NewGuid();



    //    //    var mergeRequest = MergeContactRequest.Create("Updated", "Name", "8575858", "med@gmail.com");
    //    //    var resultId = await mergeUseCase.Execute(mergeRequest);

    //    //    var updatedContact = await repository.GetSingleContactAsync(mergeRequest.Email, mergeRequest.PhoneNumber);

    //    //    // Assert
    //    //    Assert.Equal(existingContactId, resultId);
    //    //    Assert.NotNull(updatedContact);
    //    //    Assert.Equal("Updated", updatedContact.GetFirstName());
    //    //    Assert.Equal("Name", updatedContact.GetLastName());
    //    //    Assert.Equal("med@gmail.com", updatedContact.GetEmail());
    //    //    Assert.Equal("8575858", updatedContact.GetPhoneNumber());
    //    //}
    //}
}