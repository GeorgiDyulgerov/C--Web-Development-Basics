using SoftUniStore.Models;

namespace SoftUniStore.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Login> Logins { get; }

        IRepository<User> Users { get; }

        IRepository<Game> Games { get; }

        int SaveChanges();
    }



}
