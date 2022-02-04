using AutoFixture;
using AutoFixture.AutoMoq;
using System.Collections.Generic;
using System.Linq;
using TeaPicker.DataAccess.Models;
using TeaPicker.Server.Services;
using Xunit;

namespace TeaPicker.Tests
{
    public class TeaServiceTests: TestBase
    {
        private readonly TeaService _teaService;

        public TeaServiceTests(): base()
        {
            _teaService = new TeaService(_context);
        }

        [Fact]
        public void GivenValidTeaData_ShouldInsertTea()
        {

            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var teaModelPopulated = fixture.Create<Tea>();

            _teaService.Create(teaModelPopulated);

            var result = _context.Teas.FirstOrDefault(x => x.Id == teaModelPopulated.Id);

            Assert.NotNull(result);
            Assert.Equal(teaModelPopulated.Id, result.Id);

        }

        [Fact]
        public void GivenValidTeaId_ShouldReturnTea()
        {

            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var teaModelPopulated = fixture.Create<Tea>();

            _teaService.Create(teaModelPopulated);

            var result = _teaService.Get(teaModelPopulated.Id);

            Assert.IsType<Tea>(result);
            Assert.Equal(teaModelPopulated.Id, result.Id);

        }

        [Fact]
        public void GivenInvalidTeaId_ShouldNotReturnTea()
        {

            var result = _teaService.Get(333);

            Assert.Null(result);

        }

        [Fact]
        public void GivenValidTeaId_ShouldRemoveTea()
        {

            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var teaModelPopulated = fixture.Create<Tea>();

            _teaService.Create(teaModelPopulated);

            var result = _teaService.Delete(teaModelPopulated.Id);

            Assert.True(result);

        }

        [Theory]
        [InlineData(95, 4)]
        public void GivenInvalidTeaId_ShouldNotRemoveTea(double brewingTemp, double brewingTime)
        {
            var tea = new Tea()
            {
                Id = 55,
                Name = "Test 2 tea",
                BrewingTemp = brewingTemp,
                BrewingTime = brewingTime,
                Description = "sth"
            };

            _teaService.Create(tea);

            var result = _teaService.Delete(555);

            Assert.False(result);

        }

        [Fact]
        public void ShouldReturnEmptyTeaList()
        {
 
            var result = _teaService.List();

            Assert.Empty(result);

        }

        [Fact]
        public void GivenFiveTeas_ShouldReturnListWithFiveElements()
        {

            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var teaList = fixture.CreateMany<Tea>(5);

            foreach (var tea in teaList)
            {
                _teaService.Create(tea);
            }

            var result = _teaService.List();

            Assert.Equal(5, result.Count);

        }

        public static IEnumerable<object[]> DynamicDataAsProperty
        {
            get
            {
                return new[]
                {
                     new object[] { 90, 2 },
                     new object[] { 88, 6 },
                     new object[] { 96, 3 }
                };
            }
        }

        [Theory, MemberData(nameof(DynamicDataAsProperty))]
        public void GivenValidData_ShouldUpdateTeaData(double brewingTemp, double brewingTime)
        {
            var tea = new Tea()
            {
                Id = 66,
                Name = "Tea1",
                BrewingTemp = brewingTemp,
                BrewingTime = brewingTime,
                Description = "sth"
            };

            _teaService.Create(tea);

            tea.Name = "Tea2";
            tea.BrewingTemp = 94;
            tea.BrewingTime = 5;

            _teaService.Update(tea);

            var result = _teaService.Get(tea.Id);

            Assert.Equal(66, result.Id);
            Assert.Equal("Tea2", result.Name);
            Assert.Equal(94, result.BrewingTemp);
            Assert.Equal(5, result.BrewingTime);

        }

    }
}
