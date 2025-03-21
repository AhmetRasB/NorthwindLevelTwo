﻿using Business.Abstract;
using Entities.Concrete;
using Entities.DomainModels;

namespace Business.Concrete;

public class CartManager : ICartService
{
    public void AddToCart(Cart cart, Product product)
    {
        CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
        if (cartLine != null)
        {
            cartLine.Quantity++;
            return;
        }else
        {
            cart.CartLines.Add(new CartLine { Product = product, Quantity = 1 });
        }
    }

    public List<CartLine> List(Cart cart)
    {
        return (List<CartLine>)cart.CartLines;
    }

    public void RemoveFromCart(Cart cart, int productId)
    {
        cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId));
    }
}