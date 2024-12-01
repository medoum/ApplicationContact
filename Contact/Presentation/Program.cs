using Infrastructure.Repository;


Console.WriteLine("AppContact");
Console.WriteLine("Cliquez sur 1 pour ajouter un contact");


var choice = Console.ReadLine();

if (choice == "1")
{
    try
    {
        Console.Write("Entrez le prénom : ");
        var firstName = Console.ReadLine();
        Console.Write("Entrez le nom : ");
        var lastName = Console.ReadLine();
        Console.Write("Entrez le numero de telephone : ");
        var phoneNumber = Console.ReadLine();
        Console.Write("Entrez l'email : ");
        var email = Console.ReadLine();

        // Vérification de l'existence du contact
        var existingContact = ContactRepository._contacts.FirstOrDefault(c =>
            c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
            c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

        if (existingContact != null)
        {
            Console.WriteLine($"Un contact avec le prénom '{firstName}' et le nom '{lastName}' existe déjà.");
            Console.WriteLine("1. Ajouter le numéro au contact existant");
            Console.WriteLine("2. Annuler l'ajout");

            var subChoice = Console.ReadLine();
            if (subChoice == "1")
            {
                Console.Write("Entrez le numéro de téléphone à ajouter : ");
             
                existingContact.PhoneNumber = phoneNumber;
                Console.WriteLine("Numéro ajouté au contact existant avec succès.");
            }
            else
            {
                Console.WriteLine("Ajout annulé.");
            }
        }
        else
        {
         
            var newContact = ContactFactory.CreateContact(firstName, lastName, phoneNumber, email);
            
            ContactRepository._contacts.Add(newContact);
            Console.WriteLine("Nouveau contact ajouté avec succès.");
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Erreur : {ex.Message}");
    }
}
else
{
    Console.WriteLine("Option non reconnue.");
}
