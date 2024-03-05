

using BankAccount.Core.Model;
using BankAccount.Core.Ports.Driven;

namespace BankAccount.Infra
{
    public class TransactionRepository<T> : ITransactionRepository<T> where T : Account
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public TransactionRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public Task<T> GetById(int id)
        {
            using (var connection = _dbConnectionFactory.CreateConncetion())
            {
                connection.Open();
                using(var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Account WHERE Id = @id";
                    
                }
            }

        }

        public Task Save(T account)
        {
            throw new NotImplementedException();
        }
    }
}
