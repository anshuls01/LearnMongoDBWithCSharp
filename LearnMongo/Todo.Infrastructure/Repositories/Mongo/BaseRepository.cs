using Todo.Application.Interfaces;

namespace Todo.Infrastructure.Repositories.Mongo
{
    public abstract class BaseRepository<TDomain, TMongo> : IRepository<TDomain>
    {
        public Task AddAsync(TDomain enitity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string Id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TDomain>?> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TDomain?> GetByIdAsync(string Id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TDomain enitity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
