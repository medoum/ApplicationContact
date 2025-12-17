using Contact.App.Core.ContactApp.UseCase.AddContactGroup.Request;

namespace Contact.App.Core.ContactApp.UseCase.AddContactGroup
{
    public interface IAddContactGroup
    {
        Task<Guid> Execute(AddContactGroupRequest request);
    }
}