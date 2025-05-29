using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TodoAPI.Models;

namespace TodoAPI.AppDataContext{
    //inherits from DbContext
    public class TodoDbContext: DbContext{
        private readonly DbSetting _settings;
        
            //constructor injecting the DbSettings model
            public TodoDbContext(IOptions<DbSetting> dbSettings){
                _settings = dbSettings.Value;
            }

            public DbSet<Todo> Todos{get; set;}

            //configuring the db provider and connection string

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
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