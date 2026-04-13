using Contact.App.Core.ContactApp.Entity;
using Contact.App.Infrastructure.Repository;
using Contact.App.Infrastructure.UnitOfWork;

namespace Contact.App.Tests.Contact.UseCases
{
    public class AddContactUseCaseTest
    {

        [Fact]
        public async Task Execute_Should_Add_Contact_To_Group_And_Increment_Count()
        {
            // Arrange
            var contactRepository = new ContactRepository();
            var groupRepository = new ContactGroupRepository();
            var unitOfWork = new UnitOfWork();

            var group = ContactGroup.Create("Friends");
            await groupRepository.Add(group);

            var contact = Core.ContactApp.Entity.Contact.Create(
                "Med",
                "Doum",
                "0600000000",
                "med@mail.com",
                group.Id 
            );

            await contactRepository.Add(contact);

            var useCase = new AddContactToGroupUseCase(
                contactRepository,
                groupRepository,
                unitOfWork
            );

            var newGroup = ContactGroup.Create("Work");
            await groupRepository.Add(newGroup);

            // Act
            await useCase.Execute(contact.Id, newGroup.Id);

            // Assert
            var updatedContact = await contactRepository.GetById(contact.Id);
            var updatedGroup = await groupRepository.GetById(newGroup.Id);

            Assert.Contains(newGroup.Id, updatedContact.GroupIds);
            Assert.Equal(1, updatedGroup.ContactsCount);
            Assert.True(unitOfWork.IsCommitted);
        }

    }
}
