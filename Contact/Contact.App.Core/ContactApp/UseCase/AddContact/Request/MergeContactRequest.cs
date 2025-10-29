using Contact.App.Core.Shared;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Contact.App.Core.ContactApp.UseCase.AddContact.Request
{
    public class MergeContactRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? GroupId;
       

        public static MergeContactRequest Create(string firstName, string lastName, string phoneNumber, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException(ErrorMessage.FirstNameEmpty, nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(ErrorMessage.LastNameEmpty, nameof(lastName));
            if (!IsValidEmail(email))
                throw new ArgumentException(ErrorMessage.EmailEmpty, nameof(email));
            if (!IsValidPhoneNumber(phoneNumber))
                throw new ArgumentException(ErrorMessage.PhoneNumberEmpty, nameof(phoneNumber));

            return new MergeContactRequest
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };
        }
        private static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.All(char.IsDigit);
        }
       
    }

}
