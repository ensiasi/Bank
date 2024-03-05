using System.Data;

namespace BankAccount.Infra
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConncetion();
    }
}
