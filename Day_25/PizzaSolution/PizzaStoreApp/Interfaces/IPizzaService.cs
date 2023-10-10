using global::PizzaStoreApp.Models;
using PizzaStoreApp.Models;
using PizzaStoreModelLibrary;

namespace PizzaStoreApp.Interfaces
{
        public interface IPizzaService
        {
            public ICollection<PizzaWithPic> GetPizzasByRange(int min, int max);
            public ICollection<PizzaWithPic> GetPizzaByType(string type);
        }
    
}
