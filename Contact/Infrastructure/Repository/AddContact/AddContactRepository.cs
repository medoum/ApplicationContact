using Domain.Entities;
using Domain.Interface;

namespace Infrastructure.Repository.AddContact
{
    public class AddContactRepository : IAddContactRepository
    {
        public static List<Contact> _contacts = [];

        public  Task AddContactAsync(Contact contact)
        {
              _contacts.Add(contact);
               return Task.CompletedTask;
        }
    }
}
