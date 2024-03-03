using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Donton.DataAccess.Contexts
{
    public partial class DontonContext : DbContext
    {
        public override int SaveChanges()
        {
            UpdateAuditFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            UpdateAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditFields()
        {
            var currentUserId = Convert.ToInt64(_httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.PrimarySid)?.Value);

            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    Type type = entityEntry.Entity.GetType();
                    PropertyInfo propertyInfo = type.GetProperty("CreateDate");
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(entityEntry.Entity, DateTime.Now);
                    }
                    else
                    {
                    }

                    type = entityEntry.Entity.GetType();
                    propertyInfo = type.GetProperty("CreateId");
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(entityEntry.Entity, currentUserId);
                    }
                    else
                    {
               
                    }

                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    Type type = entityEntry.Entity.GetType();
                    PropertyInfo propertyInfo = type.GetProperty("LastUpdateDate");
                    if (propertyInfo != null) 
                    {
                        propertyInfo.SetValue(entityEntry.Entity, DateTime.Now);
                    }
                    else
                    {
                    }

                    type = entityEntry.Entity.GetType();
                    propertyInfo = type.GetProperty("LastUpdateId");
                    if (propertyInfo != null) 
                    {
                        propertyInfo.SetValue(entityEntry.Entity, currentUserId);
                    }
                    else
                    {
                    }

                }
            }
        }
    }

    public interface IAuditableEntity
    {
        long? CreateId { get; set; }
        long? LastUpdateId { get; set; }
        DateTime? LastUpdateDate { get; set; }
        DateTime? CreateDate { get; set; }
    }
}
