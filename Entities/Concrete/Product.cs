﻿using Core.Entities.Abstract;

namespace Entities.Concrete;

public class Product : IEntity
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; } 
    public string ProductName { get; set; }
    public string QuantityPerUnit { get; set; }
    public short UnitsInStock { get; set; } 
    public decimal UnitPrice { get; set; }

}