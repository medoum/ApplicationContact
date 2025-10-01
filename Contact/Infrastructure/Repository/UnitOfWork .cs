using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactGroupRepository _contactGroupRepository;
        private readonly ContactRepository _contactRepository;


        public UnitOfWork()
        {
            _contactGroupRepository = new ContactGroupRepository();
            _contactRepository = new ContactRepository();
        }

        public IContactGRoupRepository ContactGroups => _contactGroupRepository;
        public IContactRepository Contacts => _contactRepository;

        public Task<int> SaveChangesAsync()
        {
           
            return Task.FromResult(0);
        }
        public void Dispose()
        {
            
        }
    }
}
