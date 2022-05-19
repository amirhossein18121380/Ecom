using DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ecom.Common.DataAccess
{
    public interface ITransac
    {
        Func<Task> BeginTransaction();
        Task CommitTransaction();
        Task TransactionRoleBack();
        void Dispose();
    }

    public class Transac : ITransac
    {

        private IDbContextTransaction _transaction;

        public Func<Task> BeginTransaction()
        {
            using var context = new EcomContext();
            _transaction = context.Database.BeginTransaction();
            return CommitTransaction;
        }

        async public Task CommitTransaction()
        {
            _transaction.Commit();
            //_transaction.Dispose();
            await Task.CompletedTask;
        }

        async public Task TransactionRoleBack()
        {
            _transaction.RollbackAsync();
            //_transaction.Dispose();
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }
    }
}
