using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    /// <summary>
    /// Контекст базы данных для использования с SqLite.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new SqliteConnection("Filename=./Database.sqlite");

            optionsBuilder.UseSqlite(connection);
        }

        public DbSet<Calculation> Calculations { get; set; }
    }
}
