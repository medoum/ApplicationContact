using Contact.App.Core.ContactApp.Repository;

namespace Contact.App.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly List<Action> _operations = new();
        private bool _disposed = false;

        public void RegisterOperation(Action operation)
        {
            _operations.Add(operation);
        }

        public Task<int> SaveChangesAsync()
        {
            try
            {

                foreach (var operation in _operations)
                {
                    operation();
                }

                var operationCount = _operations.Count;
                _operations.Clear();

                return Task.FromResult(operationCount);
            }
            catch
            {

                _operations.Clear();
                throw;
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _operations.Clear();
                _disposed = true;
            }
        }
    }
}
