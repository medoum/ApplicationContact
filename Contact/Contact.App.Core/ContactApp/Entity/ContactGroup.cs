namespace Contact.App.Core.ContactApp.Entity
{
    public class ContactGroup
    {
        private Guid _id;
        private string _name;
        private int _contactnumbers;
        public ContactGroup(string name)
        {
          
            _id = Guid.NewGuid();
            _name = name;
            _contactnumbers = 0;
        }

        public Guid GetId()
        {
            return _id;
        }
        public string GetName()
        {
            return _name;
        }
     
        public void SetName(string name)
        {
            if (!string.IsNullOrEmpty(name)) 
            { 
                _name = name;
            }
        }

        public int ContactNumbers => _contactnumbers;

        public void AddContact()
        {
            _contactnumbers++;
        }

        public void RemoveContact()
        {
            if (_contactnumbers > 0)
            {
                _contactnumbers--;
            }
        }
        public static ContactGroup createGroupeContact(string name)
        {
            return new ContactGroup(name);
        }
    }
}
