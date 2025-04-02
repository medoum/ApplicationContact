using System;
using System.Threading.Tasks;
using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.UseCase.MergeContact;
using Contact.App.Core.ContactApp.Entity;
using Xunit;

namespace Contact.App.Tests.ContactApp
{
    public class MergeContactUseCaseTest
    {
        [Fact]
        public async Task MergeContact_Should_Add_AdditionalPhoneNumber()
        {
            // Arrange
            var repository = new ContactRepository();
            var mergeContactUseCase = new MergeContactUseCase(repository);

            // Créer un contact initial
            var contactId = Guid.NewGuid();
            var initialContact = new MergeContactRequest
            {
                contactId = contactId,
                FirstName = "Jean",
                LastName = "Dupont",
                Email = "jean.dupont@example.com",
                PhoneNumber = "1234567890"
            };

            //// Sauvegarder le contact initial
            //await repository.AddContactAsync(initialContact);

            // Créer la requête de fusion
            var mergeRequest = new MergeContactRequest
            {
                contactId = contactId,
                PhoneNumber = "9876543210"
            };

            // Act
            await mergeContactUseCase.Execute(mergeRequest);

            // Assert
            var updatedContact = await repository.GetSingleContactAsync(contactId);
            Assert.NotNull(updatedContact);
        
        }

        [Fact]
        public async Task MergeContact_Should_Throw_Exception_When_PhoneNumber_Is_Empty()
        {
            // Arrange
            var repository = new ContactRepository();
            var mergeContactUseCase = new MergeContactUseCase(repository);

            var contactId = Guid.NewGuid();
            var mergeRequest = new MergeContactRequest
            {
                contactId = contactId,
                PhoneNumber = ""
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await mergeContactUseCase.Execute(mergeRequest)
            );
        }

        [Fact]
        public async Task MergeContact_Should_Throw_Exception_When_Contact_Not_Found()
        {
            // Arrange
            var repository = new ContactRepository();
            var mergeContactUseCase = new MergeContactUseCase(repository);

            var nonExistentContactId = Guid.NewGuid();
            var mergeRequest = new MergeContactRequest
            {
                contactId = nonExistentContactId,
                PhoneNumber = "9876543210"
            };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                async () => await mergeContactUseCase.Execute(mergeRequest)
            );
        }

       
    }
}