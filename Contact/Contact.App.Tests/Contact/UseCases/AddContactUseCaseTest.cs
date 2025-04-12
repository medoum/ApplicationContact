using Application.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.Entity;

namespace Contact.App.Tests.Contact.UseCases
{

    public class AddContactUseCaseTest
    {
        [Fact]
        public async Task AddContactUseCaseShouldReturnValidId()
        {

            //Arrange 
            var repository = new ContactRepository();
            var useCase = new AddContactUseCase(repository);

            var request = AddContactRequest.Create(
                "Med",
                "Doumb",
                "8575858",
                "med@gmail.com"
                );

            //Act 
            var resultId = await useCase.Execute(request);

            //Assert
            Assert.NotEqual(Guid.Empty, resultId);
        }

    }
}
