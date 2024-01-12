using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}