using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using BCS.Api.Models;

/*
Notes:
MySQL Provider: Make sure you have the MySQL provider for Entity Framework Core installed. You'll need Pomelo.EntityFrameworkCore.MySql or MySql.EntityFrameworkCore depending on which MySQL driver you prefer. In this example, MySql.EntityFrameworkCore is assumed.
Connection String: The connection string in OnConfiguring is hardcoded for demonstration purposes. In a production environment, you should read this from configuration (e.g., appsettings.json).
Server Version: ServerVersion.AutoDetect attempts to detect the MySQL server version from the connection string. Ensure this works with your setup or specify the version explicitly if you encounter issues.
Entity Configuration: The way you set default values or handle specific MySQL features might differ from SQL Server. Here, CURRENT_TIMESTAMP is used for the CreatedAt default value.

To use this in an ASP.NET Core application:

Add the MySQL provider to your project via NuGet:
dotnet add package MySql.EntityFrameworkCore
In your Startup.cs or Program.cs for .NET 6+, configure the DbContext:

csharp
services.AddDbContext<YourDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

Ensure your appsettings.json includes the correct MySQL connection string:

json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;User=your_user;Password=your_password;Convert Zero Datetime=True;"
  }
}

Remember to replace placeholder values (your_server, your_database, etc.) with your actual MySQL server details.
*/

namespace BCS.Api.Data
{
    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        // If you have more models like User, Comment, etc., add them here:
        // public DbSet<User> Users { get; set; }
        // public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entities here if needed. For example:

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.content).IsRequired();
                entity.Property(e => e.createdAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
                // Additional configurations for Post if necessary
            });

            // Uncomment and configure relationships if you have related entities
            // modelBuilder.Entity<Post>()
            //     .HasOne(p => p.Author)
            //     .WithMany(u => u.Posts)
            //     .HasForeignKey(p => p.AuthorId);

            // If you have other entities or need to configure relationships or indexes:
            // modelBuilder.Entity<User>().ToTable("Users");
            // modelBuilder.Entity<Comment>().HasOne(c => c.Post).WithMany(p => p.Comments).HasForeignKey(c => c.PostId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                StreamReader sr = new StreamReader("../../../aws-resources/localhost-mac-dotnet.txt");
                // This is typically not done here in production; connection strings should be injected or read from configuration
                optionsBuilder.UseMySQL(sr.ReadToEnd());
            }
        }
    }
}