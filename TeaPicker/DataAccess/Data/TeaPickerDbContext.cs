using Microsoft.EntityFrameworkCore;
using TeaPicker.DataAccess.Models;

namespace TeaPicker.DataAccess.Data
{
    public class TeaPickerDbContext: DbContext
    {

        public DbSet<Tea> Teas { get; set; }

        public TeaPickerDbContext(DbContextOptions<TeaPickerDbContext> options)
        : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }
    }
}
