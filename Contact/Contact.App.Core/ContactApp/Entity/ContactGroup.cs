namespace Contact.App.Core.ContactApp.Entity
{
    public class ContactGroup
    {
        private Guid _id;
        private string _name;
        private int _contactNumbers;

        private ContactGroup(string name)
        {
            _id = Guid.NewGuid();
            _name = name;
            _contactNumbers = 0;
        }

        public Guid GetId() => _id;
        public string GetName() => _name;
        public int ContactNumbers => _contactNumbers;

        public void Rename(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                _name = name;
        }

        public void IncrementContacts()
        {
            _contactNumbers++;
        }

        public void DecrementContacts()
        {
            if (_contactNumbers > 0)
                _contactNumbers--;
        }

        public static ContactGroup Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nom du groupe invalide.");

            return new ContactGroup(name);
        }
    }
}