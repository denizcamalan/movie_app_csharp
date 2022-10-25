using Microsoft.EntityFrameworkCore;
using movie_api.Models;

namespace movie_api.Data
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Movies>? Movies {get; set;}
        public DbSet<Users>? Users {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("Users");
                entity.Property(e => e.Id).HasColumnName("user_id");
                entity.Property(e => e.Name).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.ToTable("Movies");
                entity.Property(e => e.Id).HasColumnName("movie_id");
                entity.Property(e => e.Name).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Description).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.MovieType).HasMaxLength(30).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}