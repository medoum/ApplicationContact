namespace Contact.App.Core.ContactApp.Entity
{
    public class ContactGroup
    {
        private Guid _id;
        private string _name;
        private List<Guid> _contactIds;
        private int _contactnumbers;
        public ContactGroup(string name,int inititialCount = 0)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Group name cannot be empty");
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

        public int Contactnumbers()
        {
            return _contactnumbers;
        }

        public void IncrementContactCount()
        {
            _contactnumbers++;
        }

        public void DecrementContactCount()
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
