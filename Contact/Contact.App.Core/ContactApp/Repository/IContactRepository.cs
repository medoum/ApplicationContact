
namespace Contact.App.Core.ContactApp.Repository;


public interface IContactRepository
{
    Task<Entity.Contact> GetById(Guid id);
    Task Add(Entity.Contact contact);
    Task Update(Entity.Contact contact);
}
