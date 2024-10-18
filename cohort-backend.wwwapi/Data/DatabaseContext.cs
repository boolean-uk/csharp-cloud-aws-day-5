using cohort_backend.wwwapi.Models;
using Microsoft.EntityFrameworkCore;

namespace cohort_backend.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Seed data
            modelBuilder.Entity<User>().HasData(
               new User { Id = 1, FirstName = "Julia", LastName = "Doe", Street = "Lakkegata", City = "Oslo",  Email = "julia@gmail.com", FavoriteColor = "#FFC0CB" },
               new User { Id = 2, FirstName = "John", LastName = "Doe", Street = "Nannestad", City = "Gardermoen", Email = "john@gmail.com", FavoriteColor = "#0000FF" },
               new User { Id = 3, FirstName = "George", LastName = "Doe", Street = "Georgia", City = "Mega-City One", Email = "george@gmail.com", FavoriteColor = "#301934" }
            );

            modelBuilder.Entity<Post>().HasData(
               new Post { Id = 1, Title = "Julia's post", Content = "Hi :3", UserId = 1 },
               new Post { Id = 2, Title = "John's post", Content = "uwu", UserId = 2 },
               new Post { Id = 3, Title = "George's post", Content = "I love Judge Dredd", UserId = 3 }
            );

            modelBuilder.Entity<Comment>().HasData(
               new Comment { Id = 1, Content = "Goodbye", PostId = 1, UserId = 2 },
               new Comment { Id = 2, Content = "Kawaii", PostId = 2, UserId = 1 },
               new Comment { Id = 3, Content = "Nani", PostId = 2, UserId = 3 },
               new Comment { Id = 4, Content = "Me too!", PostId = 3, UserId = 2 },
               new Comment { Id = 5, Content = "What is that?", PostId = 3, UserId = 1 }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
