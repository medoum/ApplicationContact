using Contact.App.Core.ContactApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DbSet<T> where T : class
    {
        private readonly ContactDbContext _context;
        private readonly List<T> _data;
        private readonly List<object> _addedEntities;
        private readonly List<object> _modifiedEntities;
        private readonly List<object> _deletedEntities;

        public DbSet(
            ContactDbContext context,
            List<T> data,
            List<object> addedEntities,
            List<object> modifiedEntities,
            List<object> deletedEntities)
        {
            _context = context;
            _data = data;
            _addedEntities = addedEntities;
            _modifiedEntities = modifiedEntities;
            _deletedEntities = deletedEntities;
        }


        public Task AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (!_addedEntities.Contains(entity))
            {
                _addedEntities.Add(entity);
            }

            return Task.CompletedTask;
        }


        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (!_modifiedEntities.Contains(entity) && !_addedEntities.Contains(entity))
            {
                _modifiedEntities.Add(entity);
            }
        }


        public void Remove(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (_addedEntities.Contains(entity))
            {
                _addedEntities.Remove(entity);
            }
            else if (!_deletedEntities.Contains(entity))
            {
                _deletedEntities.Add(entity);
            }

            if (_modifiedEntities.Contains(entity))
            {
                _modifiedEntities.Remove(entity);
            }
        }

        public Task<T> FindAsync(Guid id)
        {
            T entity = null;

            if (typeof(T) == typeof(Contact.App.Core.ContactApp.Entity.Contact))
            {
                entity = _data.FirstOrDefault(e =>
                    (e as Contact.App.Core.ContactApp.Entity.Contact)?.GetId() == id);
            }
            else if (typeof(T) == typeof(ContactGroup))
            {
                entity = _data.FirstOrDefault(e =>
                    (e as ContactGroup)?.GetId() == id);
            }

            return Task.FromResult(entity);
        }


        public Task<List<T>> ToListAsync()
        {
            return Task.FromResult(_data.ToList());
        }


        public Task<T> FirstOrDefaultAsync(Func<T, bool> predicate)
        {
            var entity = _data.FirstOrDefault(predicate);
            return Task.FromResult(entity);
        }

        public Task<int> CountAsync()
        {
            return Task.FromResult(_data.Count);
        }

        public Task<bool> AnyAsync(Func<T, bool> predicate)
        {
            var exists = _data.Any(predicate);
            return Task.FromResult(exists);
        }

        public Task<List<T>> WhereAsync(Func<T, bool> predicate)
        {
            var results = _data.Where(predicate).ToList();
            return Task.FromResult(results);
        }
    }
}
