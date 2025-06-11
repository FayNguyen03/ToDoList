using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TodoAPI.Models;

/* 
document: https://database.guide/how-to-install-sql-server-on-a-mac/
run the linux container image with Docker
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=@1234MSSql" -p 1433:1433 --name todoSQL --hostname todoSQL1 -d mcr.microsoft.com/mssql/server:2025-latest
*/
namespace TodoAPI.AppDataContext
{
    //inherits from DbContext
    public class TodoDbContext : DbContext
    {
        private readonly DbSetting _settings;

        //constructor injecting the DbSettings model
        public TodoDbContext(IOptions<DbSetting> dbSettings)
        {
            _settings = dbSettings.Value;
        }

        //the collection of all entities in the context, or that can be queried from the database
        public DbSet<Todo> Todos { get; set; }

        //configuring the db provider and connection string

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_settings.ConnectionString);
        }

        // Configuring the model for the Todo entity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
                .ToTable("TodoAPI")
                .HasKey(x => x.Id);
        }
    }
}