namespace Contact.App.Infrastructure.Repository
{
using Contact.App.Core.ContactApp.Entity;
using Contact.App.Core.ContactApp.Repository;

    public class ContactGroupRepository : IContactGroupRepository
    {
        private readonly Dictionary<Guid, ContactGroup> _storage = new();

        public Task<ContactGroup> GetById(Guid id)
        {
            _storage.TryGetValue(id, out var group);
            return Task.FromResult(group);
        }

        public Task Update(ContactGroup group)
        {
            if (group == null)
                throw new ArgumentNullException(nameof(group));

            if (!_storage.ContainsKey(group.Id))
                throw new InvalidOperationException("Groupe introuvable.");

            _storage[group.Id] = group;

            return Task.CompletedTask;
        }

        // BONUS — utile pour initialisation ou tests
        public Task Add(ContactGroup group)
        {
            if (group == null)
                throw new ArgumentNullException(nameof(group));

            if (!_storage.TryAdd(group.Id, group))
                throw new InvalidOperationException("Groupe déjà existant.");

            return Task.CompletedTask;
        }
    }

}
