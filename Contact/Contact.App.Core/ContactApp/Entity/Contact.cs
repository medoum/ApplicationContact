namespace Contact.App.Core.ContactApp.Entity
{
    public class Contact
    {
        private readonly Guid _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private string _additionalPhoneNumber;
        private Guid? _groupId;

        private Contact(string firstName, string lastName, string email, string phoneNumber)
        {
            _id = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phoneNumber = phoneNumber;
        }

        public Guid GetId() => _id;
        public Guid? GetGroupId() => _groupId;

        public void AssignToGroup(Guid groupId)
        {
            if (groupId == Guid.Empty)
                throw new ArgumentException(nameof(groupId));

            _groupId = groupId;
        }

        public static Contact CreateContact(
            string firstName,
            string lastName,
            string phoneNumber,
            string email,
            Guid? groupId)
        {
            var contact = new Contact(firstName, lastName, email, phoneNumber);

            if (groupId.HasValue)
                contact.AssignToGroup(groupId.Value);

            return contact;
        }

        public bool IsValid()
        {
            return _id != Guid.Empty
                && !string.IsNullOrWhiteSpace(_firstName)
                && !string.IsNullOrWhiteSpace(_lastName)
                && !string.IsNullOrWhiteSpace(_email);
        }
    }
}
