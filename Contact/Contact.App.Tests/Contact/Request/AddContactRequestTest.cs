using Application.UseCase.AddContact.Request;
using Contact.App.Tests.Contact.Shared;
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
            Assert.Equal(ErrorMessage.FirstNameEmpty, exception.Message);
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

            Assert.Equal(ErrorMessage.LastNameEmpty, exception.Message);
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

            Assert.Equal(ErrorMessage.PhoneNumberEmpty, exception.Message);
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

            Assert.Equal(ErrorMessage.EmailEmpty, exception.Message);
        }
    }
}
