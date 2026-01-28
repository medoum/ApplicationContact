namespace Contact.App.Core.ContactApp.Entity
{
    public class ContactGroup
    {
        private readonly Guid _id;
        private string _name;
        private readonly HashSet<Guid> _contactIds = new();

        private ContactGroup(string name)
        {
            _id = Guid.NewGuid();
            Rename(name);
        }

        public Guid GetId() => _id;
        public string GetName() => _name;
        public int ContactNumbers => _contactIds.Count;

        public static ContactGroup Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nom du groupe invalide.", nameof(name));

            return new ContactGroup(name);
        }

        public void Rename(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nom du groupe invalide.", nameof(name));

            _name = name;
        }

        public void AddContact(Guid contactId)
        {
            if (contactId == Guid.Empty)
                throw new ArgumentException("ContactId invalide.", nameof(contactId));

            _contactIds.Add(contactId);
        }

        public void RemoveContact(Guid contactId)
        {
            _contactIds.Remove(contactId);
        }
    }
}
