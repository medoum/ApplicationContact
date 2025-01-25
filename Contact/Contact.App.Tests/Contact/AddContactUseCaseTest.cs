

using Application.UseCase.AddContact.Request;
namespace Contact.App.Core.ContactApp.Entity;

    public class AddContactUseCaseTest
    {
        [Fact]
        public async Task AddContact_ShouldCallAddContactAsync_WhenContactDoesNotExist()
        {
            // Arrange
            var repository = new ContactRepository();
            var useCase = new AddContactUseCase(repository);

            var request = AddContactRequest.Create(
                id: Guid.NewGuid(),  
                firstName: "Mohamed",
                lastName: "Doumbouya",
                phoneNumber: "4844854565",
                email: "med@gmail.com"
            );

            // Act
            await useCase.Execute(request, ContactAction.Remplacer); 

            // Assert
            var contacts = await repository.GetContactsAsync();
            var addedContact = contacts.FirstOrDefault();

            Assert.NotNull(addedContact);
            Assert.Equal(request.FirstName, addedContact.GetFirstName());
            Assert.Equal(request.LastName, addedContact.GetLastName());
            Assert.Equal(request.Email, addedContact.GetEmail());
            Assert.Equal(request.PhoneNumber, addedContact.GetPhoneNumber());
        }

        [Fact]
        public async Task AddContact_ShouldUpdateContact_WhenContactExists_AndActionIsRemplacer()
        {
            // Arrange
            var repository = new ContactRepository();
            var useCase = new AddContactUseCase(repository);

            var existingContact = Contact .CreateContact("John", "Doe", "1234567890", "john.doe@example.com");
            await repository.AddContactAsync(existingContact);

            var request = AddContactRequest.Create(
                id: existingContact.GetId(),  
                firstName: "Mohamed",
                lastName: "Doumbouya",
                phoneNumber: "4844854565",
                email: "med@gmail.com"
            );

            // Act
            await useCase.Execute(request, ContactAction.Remplacer);

            // Assert
            var contacts = await repository.GetContactsAsync();
            var updatedContact = contacts.FirstOrDefault(c => c.GetId() == existingContact.GetId());

            Assert.NotNull(updatedContact);
            Assert.Equal(request.FirstName, updatedContact.GetFirstName());
            Assert.Equal(request.LastName, updatedContact.GetLastName());
            Assert.Equal(request.Email, updatedContact.GetEmail());
            Assert.Equal(request.PhoneNumber, updatedContact.GetPhoneNumber());
        }

        [Fact]
        public async Task AddContact_ShouldAddAdditionalInfo_WhenActionIsCoupler()
        {
            // Arrange
            var repository = new ContactRepository();
            var useCase = new AddContactUseCase(repository);

            // Créer un contact existant
            var existingContact = Contact.CreateContact("John", "Doe", "1234567890", "john.doe@example.com");
            await repository.AddContactAsync(existingContact);

            var request = AddContactRequest.Create(
                id: existingContact.GetId(), 
                firstName: "John", 
                lastName: "Doe",
                phoneNumber: "9876543210", 
                email: "additional.email@example.com"  
            );

            // Act
            await useCase.Execute(request, ContactAction.Coupler);

            // Assert
            var contacts = await repository.GetContactsAsync();
            var updatedContact = contacts.FirstOrDefault(c => c.GetId() == existingContact.GetId());

            Assert.NotNull(updatedContact);
           
        }

        [Fact]
        public async Task AddContact_ShouldNotUpdate_WhenActionIsAnnuler()
        {
            // Arrange
            var repository = new ContactRepository();
            var useCase = new AddContactUseCase(repository);

            var existingContact = Contact.CreateContact("John", "Doe", "1234567890", "john.doe@example.com");
            await repository.AddContactAsync(existingContact);

            var request = AddContactRequest.Create(
                id: existingContact.GetId(),
                firstName: "Mohamed",
                lastName: "Doumbouya",
                phoneNumber: "4844854565",
                email: "med@gmail.com"
            );

            // Act
            await useCase.Execute(request, ContactAction.Annuler); 

            // Assert
            var contacts = await repository.GetContactsAsync();
            var notUpdatedContact = contacts.FirstOrDefault(c => c.GetId() == existingContact.GetId());

            Assert.NotNull(notUpdatedContact);
            Assert.Equal(existingContact.GetFirstName(), notUpdatedContact.GetFirstName());
            Assert.Equal(existingContact.GetLastName(), notUpdatedContact.GetLastName());
            Assert.Equal(existingContact.GetEmail(), notUpdatedContact.GetEmail());
            Assert.Equal(existingContact.GetPhoneNumber(), notUpdatedContact.GetPhoneNumber());
        }
    }

