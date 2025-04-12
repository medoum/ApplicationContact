using Application.UseCase.AddContact.Request;
using Xunit;

namespace Contact.App.Tests.Contact.Request
{
    public class AddContactRequestTest
    {
        [Fact]
        public void ShouldThrowExceptionWhenFirstNameIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(
                    firstName: "",
                    lastName: "Doumbouya",
                    phoneNumber: "4844854565",
                    email: "med@gmail.com"
                )
            );

            Assert.Equal("Le prenom ne peut pas être vide.", exception.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenLastNameIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(
                    firstName: "Mohamed",
                    lastName: "",
                    phoneNumber: "4844854565",
                    email: "med@gmail.com"
                )
            );

            Assert.Equal("Le nom ne peut pas être vide.", exception.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenPhoneNumberIsInvalid()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(
                    firstName: "Mohamed",
                    lastName: "Doumbouya",
                    phoneNumber: "",
                    email: "med@gmail.com"
                )
            );

            Assert.Equal("Le numéro de téléphone n'est pas valide.", exception.Message);
        }

        [Fact]
        public void ShouldThrowExceptionWhenEmailIsInvalid()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(
                    firstName: "Mohamed",
                    lastName: "Doumbouya",
                    phoneNumber: "0548488",
                    email: ""
                )
            );

            Assert.Equal("L'email n'est pas valide.", exception.Message);
        }
    }
}
