using ContactApp.App.Core.Contact.Entity;


namespace ContactApp
{
    public interface IContactRepository
    {
        Task AddContactAsync(Contact contact);
        //Task<List<Contact>> GetContactsAsync();
        //Task UpdateContactAsync(Contact contact);
        //Task DeleteContactAsync(Guid id);
        //Task<Contact> GetSingleContactAsync(Guid id);
    }
}
