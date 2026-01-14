using Contact.App.Core.Shared;
using System.Text.RegularExpressions;

namespace Contact.App.Core.ContactApp.UseCase.MergeContact.Request
{
    public class MergeContactRequest
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public Guid? GroupId { get; }

        private MergeContactRequest(
            string firstName,
            string lastName,
            string phoneNumber,
            string email,
            Guid? groupId)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            GroupId = groupId;
        }

        public static MergeContactRequest Create(
            string firstName,
            string lastName,
            string phoneNumber,
            string email,
            Guid? groupId = null)
        {
            //  VALIDATIONS MÉTIER
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException(ErrorMessage.FirstNameEmpty, nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(ErrorMessage.LastNameEmpty, nameof(lastName));

            if (!IsValidEmail(email))
                throw new ArgumentException(ErrorMessage.EmailEmpty, nameof(email));

            if (!IsValidPhoneNumber(phoneNumber))
                throw new ArgumentException(ErrorMessage.PhoneNumberEmpty, nameof(phoneNumber));

            return new MergeContactRequest(
                firstName,
                lastName,
                phoneNumber,
                email,
                groupId
            );
        }

        private static bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email)
                && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrWhiteSpace(phoneNumber)
                && phoneNumber.All(char.IsDigit);
        }
    }
}
