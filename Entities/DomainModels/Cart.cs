﻿using Core.Entities.Abstract;

namespace Entities.DomainModels;

public class Cart :IDomainModel
{
    public Cart()
    {
        CartLines = new List<CartLine>();
    }
    public IList<CartLine> CartLines { get; set; }
    //public decimal Total
    //{
    //    get { return CartLines.Sum(c => c.Product.UnitPrice * c.Quantity); }
    //}

}