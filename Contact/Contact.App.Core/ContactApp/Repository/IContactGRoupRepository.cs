using Contact.App.Core.ContactApp.Entity;

namespace Contact.App.Core.ContactApp.Repository
{
    public interface IContactGroupRepository
    {
        void Add(ContactGroup contactGroup);
        void Delete(Guid id);
        ContactGroup? GetById(Guid id);
        ContactGroup? GetByName(string name);
        List<ContactGroup> GetAll();
        void Update(ContactGroup contactGroup);
    }

}
