//using Contact.App.Core.ContactApp.Entity;
//using Contact.App.Core.ContactApp.UseCase.AddContact;
//using Contact.App.Core.ContactApp.UseCase.AddContact.Request;
//using Contact.App.Core.ContactApp.UseCase.MergeContact;
//using System;
//using System.Threading.Tasks;
//using Xunit;
//using ContactApp.App.Core.Shared.Exceptions;
//using Application.UseCase.AddContact.Request;

//namespace Contact.App.Tests.Contact.UseCases
//{
//    public class MergeContactUseCaseTest
//    {
//        [Fact]
//        public async Task MergeContactUseCase_ShouldReturnExistingContactId_WhenContactExists()
//        {
//            // Arrange
//            var repository = new ContactRepository();
//            var addContactUseCase = new AddContactUseCase(repository);
//            var mergeUseCase = new MergeContactUseCase(repository);

//            // Créer un contact existant
//            var existingRequest = AddContactRequest.Create("Med", "Doumb", "8575858", "med@gmail.com");
//            var existingContactId = await addContactUseCase.Execute(existingRequest);

//            // Créer une requête de fusion avec le même email/téléphone mais noms différents
//            var mergeRequest = MergeContactRequest.Create("Updated", "Name", "8575858", "med@gmail.com");

//            // Act
//            var resultId = await mergeUseCase.Execute(mergeRequest);

//            // Assert
//            Assert.Equal(existingContactId, resultId);

//            // Vérifier que le contact a été mis à jour avec les nouveaux noms
//            var updatedContact = await repository.GetSingleContactAsync(resultId);
//            Assert.Equal("Updated", updatedContact.GetFirstName());
//            Assert.Equal("Name", updatedContact.GetLastName());
//        }

//        [Fact]
//        public async Task MergeContactUseCase_ShouldThrowException_WhenContactDoesNotExist()
//        {
//            // Arrange
//            var repository = new ContactRepository();
//            var mergeUseCase = new MergeContactUseCase(repository);

//            // Créer une requête de fusion pour un contact qui n'existe pas
//            var mergeRequest = MergeContactRequest.Create("NonExistant", "User", "1234567", "nonexistant@example.com");

//            // Act & Assert
//            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => mergeUseCase.Execute(mergeRequest));
//            Assert.Equal(InvalidError.ContactNotFound, exception.Message);
//        }

//        [Fact]
//        public async Task MergeContactUseCase_ShouldUpdateAdditionalPhoneNumber_WhenPhoneNumberIsDifferent()
//        {
//            // Arrange
//            var repository = new ContactRepository();
//            var addContactUseCase = new AddContactUseCase(repository);
//            var mergeUseCase = new MergeContactUseCase(repository);

//            // Créer un contact existant
//            var existingRequest = AddContactRequest.Create("Med", "Doumb", "8575858", "med@gmail.com");
//            var existingContactId = await addContactUseCase.Execute(existingRequest);

//            // Créer une requête de fusion avec un numéro de téléphone différent
//            var mergeRequest = MergeContactRequest.Create("Med", "Doumb", "9999999", "med@gmail.com");

//            // Act
//            var resultId = await mergeUseCase.Execute(mergeRequest);

//            // Assert
//            Assert.Equal(existingContactId, resultId);

//            // Vérifier que le numéro de téléphone additionnel a été ajouté
//            var updatedContact = await repository.GetByIdAsync(resultId);
//            // Vérifier selon la façon dont votre application gère les numéros additionnels
//            // Par exemple, si vous avez une méthode pour récupérer les numéros additionnels :
//            var additionalNumbers = updatedContact.GetAdditionalPhoneNumbers();
//            Assert.Contains("9999999", additionalNumbers);
//        }
//    }
//}