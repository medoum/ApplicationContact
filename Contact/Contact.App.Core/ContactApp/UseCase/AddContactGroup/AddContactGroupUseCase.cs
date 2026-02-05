//using Contact.App.Core.ContactApp.Entity;
//using Contact.App.Core.ContactApp.Repository;
//using Contact.App.Core.ContactApp.UseCase.AddContactGroup.Request;

//namespace Contact.App.Core.ContactApp.UseCase.AddContactGroup
//{
//    public class AddContactGroupUseCase : IAddContactGroup
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public AddContactGroupUseCase(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;

//        }
//        public async Task<Guid> Execute(AddContactGroupRequest request)
//        {
//            var newGroup = ContactGroup.Create(request.Name, request.Contactnumbers);

//            _unitOfWork.ContactGroups.Add(newGroup);
//            await _unitOfWork.SaveChangesAsync();

//            return newGroup.GetId();
//        }
//    }
//}