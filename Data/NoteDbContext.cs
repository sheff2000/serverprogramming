using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Models;

namespace MyWebApiApp.Data
{
    public class NoteDbContext : DbContext
    {
        public NoteDbContext(DbContextOptions<NoteDbContext> options)
            : base(options)
        {
        }

        public DbSet<NotesTable> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NotesTable>(entity =>
            {
                entity.ToTable("Notes");
                
                // Настройка полей
                entity.Property(e => e.TitleNote).IsRequired();
                entity.Property(e => e.TextNote).IsRequired();
                entity.Property(e => e.DateCreate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.IdNote).ValueGeneratedOnAdd();
            });
        }

    }
}
