

namespace ContactApp.App.Core.Contact.UseCase.ContactList
{
    public interface IGetContactsListUsesCase
    {
        Task<List<Entity.Contact>> GetUserAsync();
    }
}
