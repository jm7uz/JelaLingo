using Microsoft.EntityFrameworkCore;
using JelaLingo.Domain.Entities;

namespace JelaLingo.Infrastructure.Persistence
{
    public class JelalingoDbContext : DbContext
    {
        public JelalingoDbContext(DbContextOptions<JelalingoDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<Asset> Assets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserLanguage>()
                .HasKey(ul => new { ul.UserId, ul.LanguageId });

            modelBuilder.Entity<Admin>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<UserLanguage>()
                .HasOne(ul => ul.User)
                .WithMany(u => u.UserLanguages)
                .HasForeignKey(ul => ul.UserId);

            modelBuilder.Entity<UserLanguage>()
                .HasOne(ul => ul.Language)
                .WithMany(l => l.UserLanguages)
                .HasForeignKey(ul => ul.LanguageId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Language)
                .WithMany(l => l.Courses)
                .HasForeignKey(c => c.LanguageId);

            modelBuilder.Entity<Topic>()
                .HasOne(t => t.Course)
                .WithMany(c => c.Topics)
                .HasForeignKey(t => t.CourseId);

            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Topic)
                .WithMany(t => t.Lessons)
                .HasForeignKey(l => l.TopicId);

            modelBuilder.Entity<Lesson>()
                .HasMany(l => l.Assets)
                .WithOne(a => a.Lesson)
                .HasForeignKey(a => a.LessonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
