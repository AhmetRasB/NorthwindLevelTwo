using System.Linq.Expressions;
using Core.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.Concrete.EntityFramework;

public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    // Data Access katmanı olutşurmak için kullanılır. 
    // Generic yapı ile tasarlanmıştır, bu şekilde her türlü veri tabanı tablosu için tekrar eden kod yazmayı önleriz.
    where TEntity : class, new() // TEntity Veri tabanında temsil edilecek herhangi bir varlık sınıfıdır (Product Customer) Burada class olması referans tipi ve bir new ile başlatılabilir olması şart koşulmuş
    where TContext : DbContext, new() // TContext Entity Framework den türetilmiş DbContext sınıfıdır. Veri tabanı işlemlerini gerçekleştirmek için bir bağlantı nesnesi sağlar. DbContext sınıfından türetilmiş olması şart koşulmuş                   
    // TEntity referans türü olmalıdır, Parametresiz kurucuya sahip olmalıdır |||| TContext DbContext türünden olmalıdır, Parametresiz kurucuya sahip olmalıdır.
{
    public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
    {
        using (TContext context = new TContext()) // Veri tabanı bağlantısı oluştur
        {
            return filter == null ?   // Eğer filtre null ise tüm verileri getir, değilse filtreleme yap
                context.Set<TEntity>().ToList() :  // Tüm verileri getir
                context.Set<TEntity>().Where(filter).ToList(); // Filtreleme yaparak verileri getir
        }
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using (TContext context = new TContext()) // Veri tabanı bağlantısı oluştur
        {
            return context.Set<TEntity>().SingleOrDefault(filter); // Filtreleme yaparak veriyi getir
        }
    }
    /* Add Methodu 
        TContext context = new TContext(): Yeni bir veri tabanı bağlantısı oluşturur. 
        context.Entry(entity) : Veri tabanı nesnesini veri tabanı ile ilişkilendirir.
        addedEntity.State = EntityState.Added : Entity State Added olarak işaretlenir EF ye bildirir.
        context.SaveChanges() : Değişiklikleri veri tabanına kaydeder.
     */
    public void Add(TEntity entity)
    {
        using (TContext context = new TContext())
        {
           var addedEntity =  context.Entry(entity);
           addedEntity.State = EntityState.Added;
           context.SaveChanges();
        }
    }
    /* Update Methodu
      Entity State Modified olarak işaretlenir EF ye bildirir.
     */
    public void Update(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
    /* Delete Methodu
      Entity State Deleted olarak işaretlenir EF ye bildirir.
     */
    public void Delete(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}