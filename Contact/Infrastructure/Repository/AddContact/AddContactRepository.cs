using Application.UseCase.AddContact.Request;
using Domain.Entities;
using Domain.Interface;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.AddContact
{
    public class AddContactRepository : IAddContactRepository
    {
        private readonly DbContext _dbContext;

        public AddContactRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddContact(Contact contact)
        {
            var newContact = new Contact
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Tel = contact.Tel,
            };

            _dbContext.contacts.Add(newContact);

        }

    }
}
