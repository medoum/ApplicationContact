using Contact.App.Core.ContactApp.Entity;


namespace Contact.App.Core.ContactApp.UseCase.AddContactGroup
{
    public interface IAddContactGroup
    {
        Task Execute(Entity.Contact contact, ContactGroup group);
    }
}
