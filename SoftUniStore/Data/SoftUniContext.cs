using SoftUniStore.Models;

namespace SoftUniStore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SoftUniContext : DbContext
    {

        public SoftUniContext()
            : base("name=SoftUniContext")
        {
        }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.Games)
                .WithMany(game => game.Users)
                .Map(
                    config =>
                    {
                        config.MapLeftKey("UserId");
                        config.MapRightKey("GameId");
                        config.ToTable("UserGames");
                    });

            base.OnModelCreating(modelBuilder);
        }

    }

}