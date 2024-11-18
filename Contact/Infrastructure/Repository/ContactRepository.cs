using Application.UseCase.AddContact.Request;
using Domain.Entities;
using Domain.Interface;

namespace Infrastructure.Repository
{
    public class ContactRepository : IContactRepository
    {
        public static List<Contact> _contacts = [];

     
        public Task AddContactAsync(Contact contact)
        {

            _contacts.Add(contact);
            return Task.CompletedTask;
        }
    }
}
