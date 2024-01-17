using ExamAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamAPI.Context
{
    public class DatabaseContext : DbContext
    {
        public DbContextOptions<DatabaseContext> options;

        public DatabaseContext() : base()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> _options) : base(_options)
        {
            options = _options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Document>(entity =>
            {
                entity.ToTable("document");

                entity.HasKey(x => x.id);
                entity.Property(x => x.id).ValueGeneratedOnAdd();
            });

            builder.Entity<DocumentHistory>(entity =>
            {
                entity.ToTable("documenthistory");

                entity.HasKey(x => x.id);
                entity.Property(x => x.id).ValueGeneratedOnAdd();

                entity.HasOne(s => s.Document).WithMany(c => c.Histories).HasForeignKey(s => s.documentid);
            });

            builder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.HasKey(x => x.dataareaid);
            });
        }

        public DbSet<Document> Document { get; set; }
        public DbSet<DocumentHistory> DocumentHistory { get; set; }
        public DbSet<Company> Company { get; set; }
    }
}