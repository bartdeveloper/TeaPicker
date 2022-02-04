using Moq;
using System;
using TeaPicker.DataAccess.Data;

namespace TeaPicker.Tests
{
    public class TestBase: IDisposable
    {
        protected readonly TeaPickerDbContext _context;
        protected readonly Mock<TeaPickerDbContext> _contextMock;

        public TestBase()
        {
            _contextMock = TeaDbContextFactory.Create();
            _context = _contextMock.Object;
        }

        public void Dispose()
        {
            TeaDbContextFactory.Destroy(_context);
        }
    }
}
