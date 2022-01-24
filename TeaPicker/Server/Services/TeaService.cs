
using TeaPicker.DataAccess.Data;
using TeaPicker.DataAccess.Models;

namespace TeaPicker.Server.Services
{
    public class TeaService : ITeaService
    {
        private readonly TeaPickerDbContext _context;

        public TeaService(TeaPickerDbContext context)
        {
            _context = context;
        }

        public Tea Create(Tea tea)
        {
            _context.Teas.Add(tea);
            _context.SaveChanges();
            return tea;
        }

        public Tea Get(int id)
        {
            return _context.Teas.FirstOrDefault(o => o.Id == id);
        }

        public List<Tea> List()
        {
            return _context.Teas.ToList();
        }

        public Tea Update(Tea newTea)
        {
            var oldTea = Get(newTea.Id);

            if (oldTea is not null)
            {
                oldTea.Name = newTea.Name;
                oldTea.Description = newTea.Description;
                oldTea.BrewingTime = newTea.BrewingTime;
                oldTea.BrewingTemp = newTea.BrewingTemp;
                oldTea.ImageUri = newTea.ImageUri;

                _context.SaveChanges();

                return newTea;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var tea = Get(id);
            if (tea is not null)
            {
                _context.Teas.Remove(tea);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
