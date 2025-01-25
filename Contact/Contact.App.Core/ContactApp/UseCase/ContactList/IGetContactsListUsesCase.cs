

namespace Contact.App.Core.ContactApp.Entity;

    public interface IGetContactsListUsesCase
    {
        Task<List<Contact>> GetUserAsync();
    }

