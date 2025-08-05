using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.UseCase.MergeContact;
using Application.UseCase.AddContact.Request;

namespace Contact.App.Tests.Contact.UseCases
{
    public class MergeContactUseCaseTest
    {
        [Fact]
        public async Task MergeContactUseCase_ShouldReturnExistingContactId_WhenContactExists()
        {
            // Arrange
            var repository = new ContactRepository();
            var addContactUseCase = new AddContactUseCase(repository);
            var mergeUseCase = new MergeContactUseCase(repository);


            // Act
            var existingRequest = AddContactRequest.Create("Med", "Doumb", "8575858", "med@gmail.com");
            var existingContactId = await addContactUseCase.Execute(existingRequest);

          
            var mergeRequest = MergeContactRequest.Create("Updated", "Name", "8575858", "med@gmail.com");
            var resultId = await mergeUseCase.Execute(mergeRequest);

            var updatedContact = await repository.GetSingleContactAsync(mergeRequest.Email, mergeRequest.PhoneNumber);

            // Assert
            Assert.Equal(existingContactId, resultId);
            Assert.Equal("Updated", updatedContact.GetFirstName());
            Assert.Equal("Name", updatedContact.GetLastName());
        }
    }
}