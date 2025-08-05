namespace Contact.App.Core.ContactApp.Entity
{
    public class ContactGroup
    {
        private Guid _id;
        private string _name;
        private List<Guid> _contactIds;

        public ContactGroup(string name, List<Guid> ContactIds)
        {
            _id = Guid.NewGuid();
            _name = name;
            _contactIds = ContactIds;
        }

        public Guid GetId()
        {
            return _id;
        }
        public string GetName()
        {
            return _name;
        }
        public List<Guid> GetContactIds() 
        { 
            return _contactIds;
        }

        public void setName(string name)
        {
            if (!string.IsNullOrEmpty(name)) 
            { 
                _name = name;
            }
        }

        public void setListContact(List<Guid> contactIds)
        {
            if (contactIds != null)
            {
                _contactIds = contactIds;
            }
        }

        public static ContactGroup createGroupeContact(string name, List<Guid> contactIds)
        {
            return new ContactGroup(name, contactIds);
        }
    }
}
