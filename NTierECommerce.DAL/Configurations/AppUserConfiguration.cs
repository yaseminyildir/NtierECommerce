using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.DAL.Configurations
{
    //AppUser sınıfı ile ilgili özelliklerin veritabanı tablosunda nasıl olması gerektiğini belirtmek için yapılandırma yapmak amacıyla yazılmış 
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Address).HasMaxLength(500);

        }
    }
}
