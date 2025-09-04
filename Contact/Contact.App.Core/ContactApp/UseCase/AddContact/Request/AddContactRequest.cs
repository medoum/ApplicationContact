using Contact.App.Core.Shared;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Application.UseCase.AddContact.Request
{
    public class AddContactRequest
    {

        public string FirstName;
        public string LastName;
        public string Email;
        public string PhoneNumber;
        public Guid? GroupId;
        public static AddContactRequest Create(string firstName, string lastName, string phoneNumber, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException(ErrorMessage.FirstNameEmpty);
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(ErrorMessage.LastNameEmpty);
            if (!IsValidEmail(email))
                throw new ArgumentException(ErrorMessage.EmailEmpty);
            if (!IsValidPhoneNumber(phoneNumber))
                throw new ArgumentException(ErrorMessage.PhoneNumberEmpty);

            return new AddContactRequest
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
