using Application.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.Entity;

namespace Contact.App.Tests.Contact.UseCases
{
    public class AddContactUseCaseTest
    {
        [Fact]
        public async Task Execute_Should_Add_Contact_And_Return_Id()
        {
            // Arrange

            var repository = new ContactRepository();
            var useCase = new AddContactUseCase(repository);

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
            Assert.Equal(groupId, addedContact.GetGroupId());
        }
    }
}
