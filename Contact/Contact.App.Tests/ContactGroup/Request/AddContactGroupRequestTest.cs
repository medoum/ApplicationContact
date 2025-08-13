using Contact.App.Core.ContactApp.UseCase.AddContactGroup.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.App.Tests.ContactGroup.Request
{
    
    public class AddContactGroupRequestTest
    {
        [Fact]
        public void Create_WithValidParameters_ShouldReturnAddContactGroupRequest()
        {
            // Arrange
            var name = "Amis";
            var contactnumbers = 1;

            // Act 
            var result = AddContactGroupRequest.Create(name, contactnumbers);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(contactnumbers, result.Contactnumbers);
        }
    }
}
