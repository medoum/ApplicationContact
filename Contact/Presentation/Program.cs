using Application.UseCase.AddContact;
using Domain.Entities;
using Infrastructure.Repository.AddContact;

var addContactRepository = new AddContactRepository();

var addContactUseCase = new AddContactUseCase(addContactRepository);

Console.WriteLine("AppContact");
Console.WriteLine("1. Ajouter un contact");

var choice = Console.ReadLine();


switch (choice)
{
    case "1":
        Console.Write("Entrez le prénom : ");
        var firstName = Console.ReadLine();
        Console.Write("Entrez le nom : ");
        var lastName = Console.ReadLine();
        Console.Write("Entrez le numéro de téléphone : ");
        var phoneNumber = Console.ReadLine();
        Console.Write("Entrez l'email : ");
        var email = Console.ReadLine();

        var contact = new Contact
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Email = email
        };
        var result = addContactUseCase.ExecuteAsync(contact);
         

        if (result.IsCompleted)
        {
            Console.WriteLine("Contact ajouté avec succès.");
        }
        else
        {
            Console.WriteLine($"Erreur : {result.Exception}");
        }
        break;
    default:
        Console.WriteLine("Option non valide.");
        break;
}
