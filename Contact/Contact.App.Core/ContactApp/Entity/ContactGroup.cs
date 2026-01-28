namespace Contact.App.Core.ContactApp.Entity
{
    public class ContactGroup
    {
        private readonly Guid _id;
        private string _name = string.Empty; 
        private readonly HashSet<Guid> _contactIds = new();

        private ContactGroup(string name, int initialCount = 0)
        {
            _id = Guid.NewGuid();
            Rename(name);

            for (int i = 0; i < initialCount; i++)
            {
                _contactIds.Add(Guid.NewGuid());
            }
        }

        public Guid GetId() => _id;
        public string GetName() => _name;
        public int ContactNumbers => _contactIds.Count;

        public static ContactGroup Create(string name, int initialCount = 0)
        {
            return new ContactGroup(name, initialCount);
        }
        public void Rename(string name)
        {
            _name = name;
        }
        public void AddContact(Guid contactId)
        {
            _contactIds.Add(contactId);
        }
        public void RemoveContact(Guid contactId)
        {
            _contactIds.Remove(contactId);
        }
    }
}
