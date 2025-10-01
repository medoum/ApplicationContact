using Application.UseCase.AddContact.Request;
using Contact.App.Core.ContactApp.UseCase.AddContactGroup;
using Contact.App.Core.ContactApp.UseCase.AddContactGroup.Request;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.App.Tests.ContactGroup.UseCases
{
    public class AddContactGroupUseCaseTest
    {
        //[Fact]
        //public async Task AddContactGroup_ShouldCorrecrGroup()
        //{
        //    // Arrange 
        //    var repository = new ContactGroupRepository();
        //    var useCase = new AddContactGroupUseCase(repository);

        //    var request = AddContactGroupRequest.Create("Famille",5);

        //    //Act
        //    var resultId = await useCase.Execute(request);

        //    //Assert
        //    var addedGRoup = await repository.GetSingleContact(request.Name);


        //    Assert.NotEqual(Guid.Empty, resultId);
        //    Assert.NotNull(addedGRoup);
        //    Assert.Equal("Famille", addedGRoup.GetName());
        //    Assert.Equal(5, addedGRoup.ContactNumbers);
        //    Assert.Equal(resultId, addedGRoup.GetId());
        //}

    }
}
