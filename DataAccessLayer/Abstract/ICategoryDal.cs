using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccessLayer.Abstract;

public interface ICategoryDal: IEntityRepository<Category>
{
    
}