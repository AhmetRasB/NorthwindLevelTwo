﻿using Entities.Concrete;

namespace Business.Abstract;

public interface ICategoryService
{
    List<Category> GetAll();
    
}