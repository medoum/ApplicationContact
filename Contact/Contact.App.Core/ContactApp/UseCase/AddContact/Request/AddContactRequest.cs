using Contact.App.Core.Shared;
using System.Text.RegularExpressions;

namespace Application.UseCase.AddContact.Request
{
   
    public class AddContactRequest
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Guid? GroupId { get; private set; }

 
        private AddContactRequest() { }

        public static AddContactRequest Create(
            string firstName,
            string lastName,
            string phoneNumber,
            string email,
            Guid? groupId = null)
        {
           
            ValidateFirstName(firstName);
            ValidateLastName(lastName);
            ValidateEmail(email);
            ValidatePhoneNumber(phoneNumber);

            return new AddContactRequest
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                GroupId = groupId
            };
        }

        private static void ValidateFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException(ErrorMessage.FirstNameEmpty, nameof(firstName));
        }

        private static void ValidateLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(ErrorMessage.LastNameEmpty, nameof(lastName));
        }

        private static void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException(ErrorMessage.EmailEmpty, nameof(email));

            if (!IsValidEmail(email))
                throw new ArgumentException("Le format de l'email est invalide.", nameof(email));
        }

        private static void ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException(ErrorMessage.PhoneNumberEmpty, nameof(phoneNumber));

            if (!IsValidPhoneNumber(phoneNumber))
                throw new ArgumentException("Le numéro de téléphone doit contenir uniquement des chiffres.", nameof(phoneNumber));
        }

        private static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit);
        }
    }
}