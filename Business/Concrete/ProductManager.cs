using Business.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
        
    }
    public List<Product> GetAll()
    {
        return _productDal.GetList();
    }

    public List<Product> GetByCategory(int categoryId)
    {
       return _productDal.GetList(p => p.CategoryId == categoryId);
    }

    public Product GetById(int productId)
    {
        return _productDal.Get(p => p.ProductId == productId);
    }
}