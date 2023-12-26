using Microsoft.EntityFrameworkCore;
using NTierECommerce.BLL.Abstracts;
using NTierECommerce.DAL.Context;
using NTierECommerce.Entities.Base;
using NTierECommerce.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Concretes
{    //BaseRepository<T> sınıfı, IRepository<T> arayüzünü uyguluyor ve bu arayüz üzerinden genel veritabanı işlemlerini gerçekleştirmeyi hedefliyor.
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ECommerceContext _context;
        private DbSet<T> _entities;

        public BaseRepository(ECommerceContext context)
        {
            //Constructor (BaseRepository): Bu metot, ECommerceContext örneğini alarak bir veritabanı bağlamı oluşturuyor
            //_entities alanına T türünde bir DbSet atıyor.
            _context = context;
            _entities = _context.Set<T>();
        }


        public async Task<string> Create(T entity)// Bu metod, T türündeki bir varlık ( veritabanı tablosunu temsil eder) alır ve bir dize sonuç döner.
          //(Task<string>), bu da bu işlemin asenkron olarak çalışabileceğini ve bir dize değeri döndüreceğini gösterir.
        {
           
            try
            {
                //_context.Set<T>().Add(entity);
                await _entities.AddAsync(entity);
                _context.SaveChangesAsync();
                return "Kayıt başarılı!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<string> Delete(T entity)// (soft delete işlemi için )
        {
            try
            {
                entity.Status = Entities.Enums.DataStatus.Deleted;//veritabanında o varlığın devre dışı bırakılması anlamına gelir  ancak aslında veritabanından tamamen kaldırılmaz. işaretlenmesi anlamına gelir.
                await _context.SaveChangesAsync();//kaydet
                return "silme";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<string> DestroyAllData(List<T> entity)
        {
            try
            {
                foreach (var entitys in entity)//listenin her bir elemanla işlem yapmak için 
                {
                    _context.Set<T>().Remove(entitys); //entitys olarak adlandırılan varlığın veritabanından kaldırılmasını sağlar.
                }

                await _context.SaveChangesAsync();
                return "Veriler başarıyla silindi!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DestroyData(T entity)
        {
            try
            {
                _context.Remove(entity);//Bu işlem, ilgili varlığın veritabanından kaldırılmasını sağlar.
                await _context.SaveChangesAsync();
                return "silme Başarılı";//onay mesajı
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public IEnumerable<T> GetAllActive()//T türündeki varlıkların bir koleksiyonunu döndürmek üzere tasarlanmıştır. Geri dönüş tipi IEnumerable<T> olarak belirtilmiş, yani bir koleksiyon veya liste şeklinde varlıkları döndürebilir.
        {
            //return _entities.AsEnumerable();
            return _entities.AsEnumerable().ToList();

        }

        public IEnumerable<T> GetAllPassive()
        {
            throw new NotImplementedException();//yapamadım
        }

        public async Task<T> GetById(int id)
        {
            //Örneğin, eğer T bir Product ise, bu metot bir ürünü belirli bir ID değerine göre getirecektir.
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<string> Update(T entity)//Adidas
        {
           
            try
            {
                _context.Set<T>().Update(entity);
                // veritabanındaki T türündeki varlıkların koleksiyonunu temsil eder.
                //entity parametresi olarak gelen varlığı güncellemek için kullanılır.
                await _context.SaveChangesAsync();
                return "Güncelleme başarılı!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
