using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierECommerce.Entities.Entities;

namespace NTierECommerce.DAL.Configurations
{
    //AppUserRole sınıfı ile ilgili özelliklerin veritabanı tablosunda nasıl olması gerektiğini belirtmek için yapılandırma yapmak amacıyla yazılmış 
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(500);
        }
    }
}
