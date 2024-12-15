using Core.DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;

namespace DataAccessLayer.Concrete.EntityFramework;

public class EfCategoryDal :EfEntityRepositoryBase<Category,NorthwindContext>, ICategoryDal
{
       
}