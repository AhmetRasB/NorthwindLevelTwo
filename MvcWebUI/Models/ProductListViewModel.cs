﻿using Entities.Concrete;

namespace MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public Category Category { get; set; }
    }
}
