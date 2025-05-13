using MongoDB.Driver;
using Todo.Application.Interfaces;
using Todo.Core.Entities;
using Todo.Infrastructure.Mongo.Models;

namespace Todo.Infrastructure.Repositories
{
    public class MongoDbAccountRepository : IAccountRepository
    {
        private readonly IMongoCollection<MongoAccount> collection;
        public MongoDbAccountRepository(IMongoClient client)
        {
            IMongoDatabase database = client.GetDatabase("AccountDb");
            collection = database.GetCollection<MongoAccount>("Accounts");
        }
        public async Task AddAsync(Account account, CancellationToken cancellationToken)
        {
            //conversion needs between Account and MongoAccount
            MongoAccount mongoAccount = MapToMongo(account);
            await collection.InsertOneAsync(mongoAccount, null, cancellationToken);
        }

        public async Task DeleteAsync(string Id, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                await collection.DeleteOneAsync(x => x.Id == Id, null, cancellationToken);
            }
        }

        public async Task<IEnumerable<Account>?> GetAllAsync(CancellationToken cancellationToken)
        {
            IEnumerable<MongoAccount> accounts = await collection.Find(_ => true).ToListAsync(cancellationToken);
            // Old way to write the code
            //return accounts.Select(x => new Account
            //{
            //    Id = x.Id,
            //    AccountHolder = x.AccountHolder,
            //    AccountType = x.AccountType,
            //    Balance = x.Balance,
            //    TransfersCompleted = x.TransfersCompleted
            //}).ToList();

            return accounts.Select(MapToDomain).ToList();

        }

        public async Task<Account?> GetByIdAsync(string Id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return null;
            }
            //MongoAccount mongoAccount = await collection.Find(x => x.Id == Id, null).FirstOrDefaultAsync(cancellationToken);
            //return MapToDomain(mongoAccount);

            //Another way to write the above statement
            return await collection.Find(x => x.Id == Id, null).FirstOrDefaultAsync(cancellationToken) is MongoAccount mongoAccount
                                                                ?MapToDomain(mongoAccount):null;
        }

        public Task UpdateAsync(Account enitity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private Account MapToDomain(MongoAccount account) => new Account
        {
            Id = account.Id,
            AccountHolder = account.AccountHolder,
            AccountType = account.AccountType,
            Balance = account.Balance,
            TransfersCompleted = account.TransfersCompleted
        };

        private MongoAccount MapToMongo(Account account) => new MongoAccount
        {
            AccountHolder = account.AccountHolder,
            AccountType = account.AccountType,
            Balance = account.Balance,
            TransfersCompleted = account.TransfersCompleted
        };


    }
}
