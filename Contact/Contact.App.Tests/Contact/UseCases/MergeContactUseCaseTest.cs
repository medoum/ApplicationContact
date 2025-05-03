using Application.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.UseCase.MergeContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.App.Tests.Contact.UseCases
{
    public class MergeContactUseCaseTest
    {


        [Fact]
        public async Task MergeContactUseCaseShouldReturnValidId()
        {
            // Arrange
            var repository = new ContactRepository();
            var addContactUseCase = new AddContactUseCase(repository);
            var mergeUseCase = new MergeContactUseCase(repository);

            var existingRequest = AddContactRequest.Create("Med", "Doumb", "8575858", "med@gmail.com");
            var existingContactId = await addContactUseCase.Execute(existingRequest);

            var mergeRequest = MergeContactRequest.Create("Med", "Doumb", "8575858", "med@gmail.com");
            var resultId =  await mergeUseCase.Execute(mergeRequest);

            Assert.Equal(existingContactId, resultId);

           
        }

    }
}
