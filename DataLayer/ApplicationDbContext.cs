using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainClasses;

namespace DataLayer
{
    public class ApplicationDbContext : DbContext,IApplicatioDbContext
    {
        public ApplicationDbContext()
            :base("RequestDb")
        {
            
        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Menu> Menues { get; set; }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .HasOptional(m => m.ParenMenu)
                .WithMany(c => c.Children)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        
    }
}
