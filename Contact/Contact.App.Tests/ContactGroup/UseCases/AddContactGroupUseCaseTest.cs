using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.UseCase.AddContactGroup;
using Contact.App.Core.ContactApp.UseCase.AddContactGroup.Request;
using Contact.App.Infrastructure.Repository;
using Contact.App.Infrastructure.UnitOfWork;

namespace Contact.App.Tests.ContactGroup.UseCases
{
    public class AddContactGroupUseCaseTest
    {
        [Fact]
        public async Task AddContactGroup_ShouldCorrecrGroup()
        {
            // Arrange 
            var contactGroupRepository = new ContactGroupRepository(); 
            var contactRepository = new ContactRepository();
            var unitOfWork = new UnitOfWork(contactGroupRepository, contactRepository);
            var useCase = new AddContactGroupUseCase(unitOfWork);

            var request = AddContactGroupRequest.Create("Famille", 5);

            // Act
            var resultId = await useCase.Execute(request);

            //Assert
            var addedGroup = unitOfWork.ContactGroups.GetById(resultId);

            Assert.NotEqual(Guid.Empty, resultId);
            Assert.NotNull(addedGroup);
            Assert.Equal(5, addedGroup.ContactNumbers);
            Assert.Equal(resultId, addedGroup.GetId());
        }
    }
}
