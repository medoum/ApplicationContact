using Contact.App.Core.Shared;

namespace Contact.App.Core.ContactApp.UseCase.AddContactGroup.Request
{
    public class AddContactGroupRequest
    {
        public string Name;
        public int Contactnumbers;

        public static AddContactGroupRequest Create(string name, int initialCount = 0)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(ErrorMessage.Name);
            }

            return new AddContactGroupRequest 
            { 
                Name = name, 
                Contactnumbers = initialCount
            };
        }
    }
}
