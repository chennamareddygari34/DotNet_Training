using PizzaStoreApp.Models;
using PizzaStoreModelLibrary;

namespace PizzaStoreApp.Interfaces
{
    public interface IManagePizzaService
    {
        PizzaWithPic AddPizza(PizzaWithPic pizza);
        PizzaWithPic UpdatePizzaPrice(PizzaWithPic pizza);
        PizzaWithPic UpdatePizzaQuantity(PizzaWithPic pizza);

    }
}
