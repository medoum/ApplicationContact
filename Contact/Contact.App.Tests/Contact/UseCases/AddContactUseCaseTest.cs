using Application.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.Entity;
using Infrastructure.Repository;
using Xunit;
using System;
using System.Threading.Tasks;

namespace Contact.App.Tests.Contact.UseCases
{
    public class AddContactUseCaseTest
    {
        [Fact]
        public async Task Execute_Should_Add_Contact_And_Return_Id()
        {
            // Arrange
            var unitOfWork = new UnitOfWork();
            var repository = new ContactRepository(unitOfWork);
            var useCase = new AddContactUseCase(unitOfWork, repository);

            var groupId = Guid.NewGuid();

            var request = AddContactRequest.Create(
                firstName: "Mohamed",
                lastName: "Doumbouya",
                phoneNumber: "0585545",
                email: "mo@gmail.com",
                groupId: groupId
            );

            // Act
            var resultId = await useCase.Execute(request);
            var addedContact = await repository.GetSingleContactAsync(
                request.Email,
                request.PhoneNumber
            );

            // Assert
            Assert.NotEqual(Guid.Empty, resultId);
            Assert.NotNull(addedContact);
            Assert.Equal(resultId, addedContact!.GetId());
            Assert.Equal(groupId, addedContact.GetGroupID());
        }
    }
}
