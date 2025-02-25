using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Persistence
{
    public interface IMovieDbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected void OnModelCreating(ModelBuilder modelBuilder);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        public int SaveChanges();

        public EntityEntry Update(object entity);
    }
}