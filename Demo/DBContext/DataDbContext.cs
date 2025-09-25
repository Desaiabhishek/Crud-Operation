using Demo.Interfaces;
using Demo.Modules;
using Microsoft.EntityFrameworkCore;
namespace Demo.DBContext
{
    public class DataDbContext : DbContext ,IDataDbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        { }

        public virtual DbSet<Product>  Products { get; set; }
    }
}
