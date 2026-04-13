//namespace Infrastructure.Data
//{
//    public class ContactDbContext
//    {
//        public List<Contact.App.Core.ContactApp.Entity.Contact> Contacts { get; } = new();

//        internal List<object> AddedEntities { get; } = new();
//        internal List<object> ModifiedEntities { get; } = new();
//        internal List<object> DeletedEntities { get; } = new();

//        public DbSet<Contact.App.Core.ContactApp.Entity.Contact> ContactsSet =>
//            new DbSet<Contact.App.Core.ContactApp.Entity.Contact>(
//                this,
//                Contacts,
//                AddedEntities,
//                ModifiedEntities,
//                DeletedEntities
//            );
//    }
//}
