using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccessLayer.Abstract;

public interface IProductDal: IEntityRepository<Product>
{
    
    // Listeleme
    // Ekleme
    // Silme
    // Güncelleme
}