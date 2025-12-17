using Contact.App.Core.ContactApp.Entity;

namespace Infrastructure.Data
{
    
    public class ContactDbContext : IDisposable
    {
     
        private readonly List<Contact.App.Core.ContactApp.Entity.Contact> _contacts;
        private readonly List<ContactGroup> _contactGroups;

  
        private readonly List<object> _addedEntities;
        private readonly List<object> _modifiedEntities;
        private readonly List<object> _deletedEntities;

        private bool _disposed = false;

        public ContactDbContext()
        {
         
            _contacts = new List<Contact.App.Core.ContactApp.Entity.Contact>();
            _contactGroups = new List<ContactGroup>();

        
            _addedEntities = new List<object>();
            _modifiedEntities = new List<object>();
            _deletedEntities = new List<object>();

           
            Contacts = new DbSet<Contact.App.Core.ContactApp.Entity.Contact>(
                this,
                _contacts,
                _addedEntities,
                _modifiedEntities,
                _deletedEntities
            );

            ContactGroups = new DbSet<ContactGroup>(
                this,
                _contactGroups,
                _addedEntities,
                _modifiedEntities,
                _deletedEntities
            );
        }

      
        public DbSet<Contact.App.Core.ContactApp.Entity.Contact> Contacts { get; }

        public DbSet<ContactGroup> ContactGroups { get; }

        public Task<int> SaveChangesAsync()
        {
            int changeCount = 0;

            try
            {
                // Traitement des suppressions
                foreach (var entity in _deletedEntities.ToList())
                {
                    if (entity is Contact.App.Core.ContactApp.Entity.Contact contact)
                    {
                        _contacts.Remove(contact);
                        changeCount++;
                    }
                    else if (entity is ContactGroup group)
                    {
                        _contactGroups.Remove(group);
                        changeCount++;
                    }
                }

                // Traitement les ajouts
                foreach (var entity in _addedEntities.ToList())
                {
                    if (entity is Contact.App.Core.ContactApp.Entity.Contact contact)
                    {
                        if (!_contacts.Contains(contact))
                        {
                            _contacts.Add(contact);
                            changeCount++;
                        }
                    }
                    else if (entity is ContactGroup group)
                    {
                        if (!_contactGroups.Contains(group))
                        {
                            _contactGroups.Add(group);
                            changeCount++;
                        }
                    }
                }

                // Traitement les modifications
                foreach (var entity in _modifiedEntities.ToList())
                {
                    if (entity is Contact.App.Core.ContactApp.Entity.Contact contact)
                    {
                        var index = _contacts.FindIndex(c => c.GetId() == contact.GetId());
                        if (index >= 0)
                        {
                            _contacts[index] = contact;
                            changeCount++;
                        }
                    }
                    else if (entity is ContactGroup group)
                    {
                        var index = _contactGroups.FindIndex(g => g.GetId() == group.GetId());
                        if (index >= 0)
                        {
                            _contactGroups[index] = group;
                            changeCount++;
                        }
                    }
                }

             
                _addedEntities.Clear();
                _modifiedEntities.Clear();
                _deletedEntities.Clear();

                return Task.FromResult(changeCount);
            }
            catch
            {
               
                _addedEntities.Clear();
                _modifiedEntities.Clear();
                _deletedEntities.Clear();
                throw;
            }
        }

        public int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }

        public void DetachAll()
        {
            _addedEntities.Clear();
            _modifiedEntities.Clear();
            _deletedEntities.Clear();
        }

        public int GetPendingChangesCount()
        {
            return _addedEntities.Count + _modifiedEntities.Count + _deletedEntities.Count;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                DetachAll();
                _contacts.Clear();
                _contactGroups.Clear();
                _disposed = true;
            }
        }
    }

  
}