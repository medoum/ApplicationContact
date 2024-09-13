namespace Application.UseCase.AddContact.Exceptions
{
    public class ContactAlreadyExistsException : Exception
    {
        public ContactAlreadyExistsException() : base("Le contact exist deja.")
        {
        }

        public ContactAlreadyExistsException(string message) : base(message)
        {
        }

        public ContactAlreadyExistsException(string message, Exception innerException) : base(message, innerException)

        {
        }

    }
}