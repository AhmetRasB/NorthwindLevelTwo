using System.Linq.Expressions;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal
{
   
}