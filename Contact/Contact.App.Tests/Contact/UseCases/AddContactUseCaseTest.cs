using Application.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.UseCase.AddContactGroup;
using Contact.App.Core.ContactApp.UseCase.AddContactToGroup;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.App.Tests.Contact.UseCases
{
    public class AddContactUseCaseTest
    {

        [Fact]
        public async Task AddContactUsesShouldAddCorrectContact()
        {
            // Arrange
            var repository = new ContactRepository();
            var repositoryGroup = new ContactGroupRepository();
            var contactGroupUse = new AddContactToGroupUseCase(repositoryGroup, repository);
            var useCase = new AddContactUseCase(repository, contactGroupUse);

          
            var request = AddContactRequest.Create("Mohamed", "Doumbouya", "0585545", "mo@gmail.com");
           
            var resultId = await useCase.Execute(request);


            var addedContact = await repository.GetSingleContactAsync(request.Email, request.PhoneNumber);

            Assert.NotEqual(Guid.Empty, resultId);
            Assert.NotNull(addedContact);

            Assert.Equal("Mohamed", addedContact.GetFirstName());
            Assert.Equal("Doumbouya", addedContact.GetLastName());
            Assert.Equal("mo@gmail.com", addedContact.GetEmail());
            Assert.Equal("0585545", addedContact.GetPhoneNumber());
            Assert.Equal(resultId, addedContact.GetId());


        }
    }
}
