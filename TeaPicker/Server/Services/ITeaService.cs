
using TeaPicker.DataAccess.Models;

namespace TeaPicker.Server.Services
{
    public interface ITeaService
    {
        public Tea Create(Tea tea); 
        public Tea Get(int id);
        public List<Tea> List();
        public Tea Update(Tea tea);
        public bool Delete(int id);
    }
}
