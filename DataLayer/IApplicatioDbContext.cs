using System.Data.Entity;

namespace DataLayer
{
    public interface IApplicatioDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();

    }
}