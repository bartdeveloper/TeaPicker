using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using TeaPicker.DataAccess.Data;

namespace TeaPicker.Tests
{
    public static class TeaDbContextFactory
    {

        public static Mock<TeaPickerDbContext> Create()
        {
            var options = new DbContextOptionsBuilder<TeaPickerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var mock = new Mock<TeaPickerDbContext>(options) { CallBase = true };

            return mock;
        }

        public static void Destroy(TeaPickerDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

    }
}