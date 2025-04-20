using Microsoft.EntityFrameworkCore;
using CodeChallengeApp.Domain.Entities;

namespace CodeChallengeApp.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the User entity/table.
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);

                entity.Property(u => u.FullName).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(200);
            });

            // Configure the Transaction entity/table.
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Amount)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");

                entity.Property(t => t.CreatedAt)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasOne<User>()
                      .WithMany(u => u.Transactions)
                      .HasForeignKey(t => t.UserId)
                      .OnDelete(DeleteBehavior.Cascade); // Make sure this is the desired behaviour
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
