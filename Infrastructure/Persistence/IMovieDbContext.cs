using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
