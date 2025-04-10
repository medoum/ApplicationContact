using Application.UseCase.AddContact.Request;


namespace Contact.App.Tests.Contact;

public class AddContactUseCaseTest
{
 
    [Fact]
    public Task AddContactShouldThrowExceptionWhenFirstNameIsEmpty()
    {

        try
        {
            var request = AddContactRequest.Create(

           firstName: "",
           lastName: "Doumbouya",
           phoneNumber: "4844854565",
           email: "med@gmail.com"
       );
         
        }

        catch (Exception e)
        {

            Assert.Equal("Le prenom ne peut pas etre vide.", e.Message);

        }

        return Task.CompletedTask;
    }
    [Fact]
    public Task AddContactShouldThrowExceptionWhenLastNameIsEmpty()
    {
      
      
        try
        {
            var request = AddContactRequest.Create(

           firstName: "Mohamed",
           lastName: "",
           phoneNumber: "4844854565",
           email: "med@gmail.com"

       );

        }

        catch (ArgumentException e)
        {

            Assert.Equal("le nom ne peut pas etre vide", e.Message);

        }

        return Task.CompletedTask;
    }


    [Fact]
    public Task AddContactShouldThrowExceptionWhenPhoneNumberIsEmpty()
    {

        try
        {
            var request = AddContactRequest.Create(

           firstName: "Mohamed",
           lastName: "Doumbouya",
           phoneNumber: "",
           email: "med@gmail.com"

       );

        }

        catch (ArgumentException e)
        {


            Assert.Equal("le numero ne peut pas etre vide", e.Message);

        }

        return Task.CompletedTask;
    }

    [Fact]
    public Task AddContactShouldThrowExceptionWhenEmailIsEmpty()
    {
        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var request = AddContactRequest.Create(
                firstName: "Mohamed",
                lastName: "Doumbouya",
                phoneNumber: "0548488",
                email: ""
            );
        });

        Assert.Equal("L'email n'est pas valide.", exception.Message);

        return Task.CompletedTask;
    }



}