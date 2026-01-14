using Application.UseCase.AddContact.Request;
using Xunit;

namespace Application.Tests.UseCase.AddContact.Request
{
    public class AddContactRequestTests
    {
        
        [Fact]
        public void Create_WithValidParameters_ShouldReturnAddContactRequest()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var phoneNumber = "1234567890";
            var email = "john.doe@example.com";

            // Act
            var result = AddContactRequest.Create(firstName, lastName, phoneNumber, email);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(firstName, result.FirstName);
            Assert.Equal(lastName, result.LastName);
            Assert.Equal(email, result.Email);
            Assert.Equal(phoneNumber, result.PhoneNumber);
        }

        [Fact]
        public void Create_WithValidParametersAndGroupId_ShouldReturnAddContactRequest()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var phoneNumber = "1234567890";
            var email = "john.doe@example.com";
            var groupId = Guid.NewGuid();

            // Act
            var result = AddContactRequest.Create(firstName, lastName, phoneNumber, email, groupId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(groupId, result.GroupId);
        }

        [Fact]
        public void Create_WithValidPhoneNumbers_ShouldReturnAddContactRequest()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var email = "john.doe@example.com";
            var validPhoneNumbers = new[]
            {
                "1234567890",
                "123456789",
                "12345678901234567890",
                "0"
            };

            // Act & Assert
            foreach (var phoneNumber in validPhoneNumbers)
            {
                var result = AddContactRequest.Create(firstName, lastName, phoneNumber, email);
                Assert.NotNull(result);
                Assert.Equal(phoneNumber, result.PhoneNumber);
            }
        }

  
        [Fact]
        public void Create_WithEmptyFirstName_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "";
            var lastName = "Doe";
            var phoneNumber = "1234567890";
            var email = "john.doe@example.com";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("firstName", exception.ParamName);
        }

        [Fact]
        public void Create_WithNullFirstName_ShouldThrowArgumentException()
        {
            // Arrange
            string firstName = null;
            var lastName = "Doe";
            var phoneNumber = "1234567890";
            var email = "john.doe@example.com";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("firstName", exception.ParamName);
        }

        [Fact]
        public void Create_WithWhiteSpaceFirstName_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "   ";
            var lastName = "Doe";
            var phoneNumber = "1234567890";
            var email = "john.doe@example.com";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("firstName", exception.ParamName);
        }


        [Fact]
        public void Create_WithEmptyLastName_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "John";
            var lastName = "";
            var phoneNumber = "1234567890";
            var email = "john.doe@example.com";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("lastName", exception.ParamName);
        }

        [Fact]
        public void Create_WithNullLastName_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "John";
            string lastName = null;
            var phoneNumber = "1234567890";
            var email = "john.doe@example.com";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("lastName", exception.ParamName);
        }

        [Fact]
        public void Create_WithWhiteSpaceLastName_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "John";
            var lastName = "   ";
            var phoneNumber = "1234567890";
            var email = "john.doe@example.com";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("lastName", exception.ParamName);
        }


        [Fact]
        public void Create_WithInvalidEmail_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var phoneNumber = "1234567890";
            var email = "invalid-email";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("email", exception.ParamName);
        }

        [Fact]
        public void Create_WithEmptyEmail_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var phoneNumber = "1234567890";
            var email = "";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("email", exception.ParamName);
        }

        [Fact]
        public void Create_WithNullEmail_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var phoneNumber = "1234567890";
            string email = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("email", exception.ParamName);
        }

        [Fact]
        public void Create_WithEmailWithoutAtSymbol_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var phoneNumber = "1234567890";
            var email = "johndoeexample.com";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("email", exception.ParamName);
        }

        [Fact]
        public void Create_WithEmailWithoutDomain_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var phoneNumber = "1234567890";
            var email = "john.doe@";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("email", exception.ParamName);
        }

        [Fact]
        public void Create_WithInvalidPhoneNumber_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var phoneNumber = "123abc456";
            var email = "john.doe@example.com";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("phoneNumber", exception.ParamName);
        }

        [Fact]
        public void Create_WithEmptyPhoneNumber_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var phoneNumber = "";
            var email = "john.doe@example.com";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("phoneNumber", exception.ParamName);
        }

        [Fact]
        public void Create_WithNullPhoneNumber_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            string phoneNumber = null;
            var email = "john.doe@example.com";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("phoneNumber", exception.ParamName);
        }

        [Fact]
        public void Create_WithWhiteSpacePhoneNumber_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var phoneNumber = "   ";
            var email = "john.doe@example.com";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("phoneNumber", exception.ParamName);
        }

        [Fact]
        public void Create_WithPhoneNumberContainingSpaces_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var phoneNumber = "123 456 7890";
            var email = "john.doe@example.com";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("phoneNumber", exception.ParamName);
        }

        [Fact]
        public void Create_WithPhoneNumberContainingSpecialCharacters_ShouldThrowArgumentException()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var phoneNumber = "123-456-7890";
            var email = "john.doe@example.com";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                AddContactRequest.Create(firstName, lastName, phoneNumber, email));

            Assert.Equal("phoneNumber", exception.ParamName);
        }

     
    }
}