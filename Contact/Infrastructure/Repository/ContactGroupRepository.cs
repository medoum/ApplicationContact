using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.Repository;

namespace Infrastructure.Repository
{
    public class ContactGroupRepository : IContactGRoupRepository
    {
        private static readonly List<ContactGroup> _groups = new();
        private readonly UnitOfWork _unitOfWork;

        public ContactGroupRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public Task AddAsync(ContactGroup contactGroup)
        {
            _unitOfWork.RegisterOperation(() =>
            {
                _groups.Add(contactGroup);
            });

            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _unitOfWork.RegisterOperation(() =>
            {
                var group = _groups.FirstOrDefault(g => g.GetId() == id);
                if (group != null)
                {
                    _groups.Remove(group);
                }
            });

            return Task.CompletedTask;
        }

        public Task<List<ContactGroup>> GetAllAsync()
        {
            return Task.FromResult(_groups.ToList());
        }

        public Task<ContactGroup> GetByIdAsync(Guid id)
        {
            var contactGroup = _groups.FirstOrDefault(c => c.GetId() == id);
            return Task.FromResult(contactGroup);
        }

        public Task<ContactGroup> GetSingleContact(string name)
        {
            var contact = _groups.FirstOrDefault(c => c.GetName() == name);
            return Task.FromResult(contact);
        }

        public Task UpdateAsync(ContactGroup contactGroup)
        {
            _unitOfWork.RegisterOperation(() =>
            {
                var index = _groups.FindIndex(g => g.GetId() == contactGroup.GetId());
                if (index >= 0)
                {
                    _groups[index] = contactGroup;
                }
            });

            return Task.CompletedTask;
        }
    }
}