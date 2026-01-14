using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.Repository;

namespace Infrastructure.Repository
{
    public class ContactGroupRepository : IContactGroupRepository
    {
        private readonly List<ContactGroup> _groups = new();
        private readonly IUnitOfWork _unitOfWork;

        public ContactGroupRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task AddAsync(ContactGroup contactGroup)
        {
            if (contactGroup == null)
                throw new ArgumentNullException(nameof(contactGroup));

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

        public Task<ContactGroup?> GetByIdAsync(Guid id)
        {
            var group = _groups.FirstOrDefault(g => g.GetId() == id);
            return Task.FromResult(group);
        }

        public Task<ContactGroup?> GetByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Le nom du groupe est invalide.", nameof(name));

            var group = _groups.FirstOrDefault(g => g.GetName() == name);
            return Task.FromResult(group);
        }

        public Task UpdateAsync(ContactGroup contactGroup)
        {
            if (contactGroup == null)
                throw new ArgumentNullException(nameof(contactGroup));

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
