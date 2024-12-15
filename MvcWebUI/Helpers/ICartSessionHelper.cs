using Entities.DomainModels;

namespace MvcWebUI.Helpers;

public interface ICartSessionHelper
{
    Cart getCart(string key);
    void setCart(string key,Cart cart);
    void Clear();

}