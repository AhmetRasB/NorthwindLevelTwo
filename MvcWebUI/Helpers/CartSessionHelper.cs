using Entities.DomainModels;
using MvcWebUI.Extensions;

namespace MvcWebUI.Helpers;

public class CartSessionHelper : ICartSessionHelper
{
    private IHttpContextAccessor _httpContextAccessor;

    public CartSessionHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Cart getCart(string key)
    {
        // Parametre olarak gelen key'i kullan
        Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>(key);
        if (cartToCheck == null)
        {
            setCart(key, new Cart());  // Eğer sepet bulunamazsa yeni bir sepet oluştur
            cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>(key);  // Yeni sepeti al
        }

        return cartToCheck;
    }

    public void setCart(string key, Cart cart)
    {
        _httpContextAccessor.HttpContext.Session.SetObject(key, cart);
    }

    public void Clear()
    {
        _httpContextAccessor.HttpContext.Session.Clear();
    }
}