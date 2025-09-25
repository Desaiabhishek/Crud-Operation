using Demo.Modules;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Demo.Interfaces
{
    public interface IDataDbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
