using System.Security.Cryptography;

namespace ContactApp.App.Core.Contact.Entity
{
    public class Contact
    {
        private Guid Id;
        private string FirstName;

        private string LastName;

        private string PhoneNumber;

        private string Email;

        private Contact(Guid id, string firstName, string lastName, string phoneNumber, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public Guid GetId()
        {
            return Id;
        }
        public string GetFirsName()
        {
            return FirstName;
        }

        public string GetLastName()
        {
            return LastName;
        }
        public string GetPhoneNumber()
        {
            return PhoneNumber;
        }

        public string GetEmail()
        {
            return Email;
        }

        public static Contact CreateContact(Guid id, string firstName, string lastName, string phoneNumber, string email)
        {
            return new Contact(id, firstName, lastName, phoneNumber,email);
        }
    }
}
