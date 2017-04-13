using SoftUniStore.Data.Contracts;
using SoftUniStore.Data.Repositories;
using SoftUniStore.Models;

namespace SoftUniStore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SoftUniContext context;
        private IRepository<Login> logins;
        private IRepository<User> users;
        private IRepository<Game> games;

        public UnitOfWork()
        {
            this.context = Data.Context;
        }

        public IRepository<Login> Logins
            => this.logins ?? (this.logins = new Repository<Login>(this.context.Logins));

        public IRepository<User> Users
            => this.users ?? (this.users = new Repository<User>(this.context.Users));

        public IRepository<Game> Games
            => this.games ?? (this.games = new Repository<Game>(this.context.Games));

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
