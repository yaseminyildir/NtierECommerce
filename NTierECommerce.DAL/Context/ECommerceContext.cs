using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NTierECommerce.DAL.Configurations;
using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.DAL.Context
{
    public class ECommerceContext:IdentityDbContext<AppUser,AppUserRole,int>
    {
        //Bağlamın Oluşturulması
        public ECommerceContext()
        {
            //Birinci constructor varsayılan değerlerle çalışır
        }
        public ECommerceContext(DbContextOptions<ECommerceContext> options):base(options)
        {
            // ikinci constructor ise DbContextOptions ile birlikte kullanılacak ve dışarıdan gelen yapılandırma seçeneklerini alacak şekilde tasarlanmış
        }



        //Tabloların Tanımlanması :DbSet<Product> ve DbSet<Category> gibi özellikler, Product ve Category sınıflarının veritabanındaki tablolara karşılık geleceğini belirtir.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }



        //Model Yapısının Oluşturulması:veritabanı modelinin nasıl oluşturulacağı ve yapılandırılacağı tanımlanır
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //AppUser
            builder.ApplyConfiguration(new AppUserConfiguration());

            //AppUserRole
            builder.ApplyConfiguration(new AppUserRoleConfiguration());


            //Category
            builder.ApplyConfiguration(new CategoryConfiguration());

            //Product
            builder.ApplyConfiguration(new ProductConfiguration());



            base.OnModelCreating(builder);
        }

        //Veritabanı Bağlantısının Yapılandırılması:veritabanı bağlantısının nasıl yapılandırılacağı belirtilmiş.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("server=YASEMIN\\YASEMIN;database=EcommerceNtier;Trusted_Connection=True;TrustServerCertificate=True");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
