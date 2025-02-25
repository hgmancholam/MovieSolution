using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.IO;
using Nest;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Persistence
{
    public class MovieDbContext : DbContext, IMovieDbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Inception", Director = "Giovanny", Year = 2010 },
                new Movie { Id = 2, Title = "Inception2", Director = "Giovanny", Year = 2011 },
                new Movie { Id = 3, Title = "Inception3", Director = "Giovanny", Year = 2012 },
                new Movie { Id = 4, Title = "Inception4", Director = "Giovanny", Year = 2013 },
                new Movie { Id = 5, Title = "Inception5", Director = "Giovanny", Year = 2014 }

            );
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override EntityEntry Update(object entity)
        {
            try
            {
                return base.Update(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        void IMovieDbContext.OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreating(modelBuilder);
        }
    }
}