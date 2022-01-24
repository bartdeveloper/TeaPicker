
using TeaPicker.DataAccess.Models;
using TeaPicker.DataAccess.Repository;

namespace TeaPicker.Server.Services
{
    public interface ITeaService: IRepository<Tea>
    {
        public Tea Create(Tea tea); 
        public Tea GetById(int id);
        public List<Tea> List();
        public Tea Update(Tea tea);
        public bool Delete(int id);
    }
}
