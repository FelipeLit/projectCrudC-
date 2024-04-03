using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
namespace Proyecto.Data
 {
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext>options) : base(options)
        {

        }

        public DbSet<User> Users {get; set;}
        public DbSet<Product> Products {get; set;}
    }
 }