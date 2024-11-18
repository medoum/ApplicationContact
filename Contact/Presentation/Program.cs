using Application.UseCase.AddContact.Factory;

class Program
{
    static async Task Main(string[] args)
    {
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

        
                var contact = ContactFactory.CreateContact(firstName, lastName, phoneNumber, email);

                var addContactUseCase = UseCaseFactory.CreateAddContactUseCase();

                try
                {
                    await addContactUseCase.ExecuteAsync(contact);
                    Console.WriteLine("Contact ajouté avec succès.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur : {ex.Message}");
                }
                break;

            default:
                Console.WriteLine("Option non valide.");
                break;
        }
    }
}
