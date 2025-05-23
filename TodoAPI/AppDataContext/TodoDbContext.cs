using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TodoAPI.Models;

namespace TodoAPI.AppDataContext{
    //inherits from DbContext
    public class TodoDbContext: DbContext{
        private readonly DbSettings _settings;
        
            //constructor injecting the DbSettings model
            public TodoDbContext(IOptions<DbSetting> dbSettings){
                _settings = dbSettings;
            }

            public DbSet<Todo> Todos{get; set;}

            //configuring the db provider and connection string

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
                
            }
    }
}