using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.Repository;

namespace Infrastructure.Repository
{
    public class ContactGroupRepository : IContactGRoupRepository
    {
        private readonly List<ContactGroup> _groups = [];
        public Task AddAsync(ContactGroup contactGroup)
        {
           _groups.Add(contactGroup);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            var group = _groups.FirstOrDefault(g => g.GetId() == id);
            if (group != null) 
            { 
                _groups.Remove(group);
            }
            return Task.CompletedTask;
        }

        public Task<List<ContactGroup>> GetAllAsync()
        {
            return Task.FromResult( _groups.ToList());
        }

        public Task<ContactGroup> GetByIdAsync(Guid id)
        {
            var contactGroup = _groups.FirstOrDefault( c => c.GetId() == id);
            return Task.FromResult<ContactGroup>(contactGroup);
        }

        public Task<ContactGroup> GetSingleContact(string Name)
        {
            var contact = _groups.FirstOrDefault(c => c.GetName() == Name);
            return Task.FromResult<ContactGroup>(contact);
        }

        public Task UpdateAsync(ContactGroup contactGroup)
        {
            var index = _groups.FindIndex(g=> g.GetId() == contactGroup.GetId());
            if(index > 0)
            {
                _groups[index] = contactGroup;
            }
            return Task.CompletedTask ;
        }
    }
}
