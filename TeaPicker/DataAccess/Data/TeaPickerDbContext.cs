using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaPicker.DataAccess.Data;
using TeaPicker.Shared;

namespace TeaPicker.DataAccess
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
