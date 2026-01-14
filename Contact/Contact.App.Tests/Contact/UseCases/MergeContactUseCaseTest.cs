using Application.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.UseCase.AddContactToGroup;
using Contact.App.Core.ContactApp.UseCase.MergeContact;
using Contact.App.Core.ContactApp.UseCase.MergeContact.Request;
using Infrastructure.Repository;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Contact.App.Tests.Contact.UseCases
{
    public class MergeContactUseCaseTest
    {
        [Fact]
        public async Task Execute_Should_Merge_Contact_And_Assign_Group_When_GroupId_Provided()
        {
            // Arrange
          
            var unitOfWork = new UnitOfWork();

            var contactRepository = new ContactRepository(unitOfWork);
            var groupRepository = new ContactGroupRepository(unitOfWork);

             var addContactToGroupUseCase =
              new AddContactToGroupUseCase(
                  groupRepository,
                  contactRepository
              );


            var addContactUseCase =
                new AddContactUseCase(unitOfWork, contactRepository);

            var mergeContactUseCase = new MergeContactUseCase(
                contactRepository,
                unitOfWork,
                addContactToGroupUseCase
            );

            // création réelle du groupe
            var group = Core.ContactApp.Entity.ContactGroup.Create("Friends");
            await groupRepository.AddAsync(group);
            await unitOfWork.SaveChangesAsync();

            // création du contact initial
            var createRequest = AddContactRequest.Create(
                "Med",
                "Doumb",
                "8575858",
                "med@gmail.com",
                null
            );

            var existingContactId = await addContactUseCase.Execute(createRequest);

            // Act
            var mergeRequest = MergeContactRequest.Create(
                "Updated",
                "Name",
                "8575858",
                "med@gmail.com",
                group.GetId()
            );

            var resultId = await mergeContactUseCase.Execute(mergeRequest);

            var updatedContact =
                await contactRepository.GetSingleContactAsync(
                    "med@gmail.com",
                    "8575858"
                );

            var updatedGroup =
                await groupRepository.GetByIdAsync(group.GetId());

            // Assert

            Assert.NotNull(updatedContact);
            Assert.NotNull(updatedGroup);

            Assert.Equal(existingContactId, resultId);
            Assert.Equal("Updated", updatedContact!.GetFirstName());
            Assert.Equal("Name", updatedContact.GetLastName());
            Assert.Equal("med@gmail.com", updatedContact.GetEmail());
            Assert.Equal("8575858", updatedContact.GetPhoneNumber());

            Assert.Equal(1, updatedGroup!.ContactNumbers);
        }
    }
}
