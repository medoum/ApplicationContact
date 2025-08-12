namespace Contact.App.Core.ContactApp.Entity
{
    public class ContactGroup
    {
        private Guid _id;
        private string _name;
        private int _contactnumbers;
        public ContactGroup(string name,int inititialCount = 0)
        {
          
            _id = Guid.NewGuid();
            _name = name;
            _contactnumbers = inititialCount;
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

        public int ConttactNumbers => _contactnumbers;

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
        public static ContactGroup createGroupeContact(string name, int initialCount=0)
        {
            return new ContactGroup(name, initialCount);
        }
    }
}
