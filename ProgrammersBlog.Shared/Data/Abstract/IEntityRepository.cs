using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract //EAGER LOADING YAPTIK
{
    //Bu repoya bir tip vericez bu tipe göre Repo işlemleri yapiyor olucaz. REPOSTIORY PATTERN
    //ASENKRON Programlama Kullanıcaz. Tüm Entitylerde Ortak olan metotları yazıyoruz.
    public interface IEntityRepository<T> where T:class,IEntity,new() //Aldıgımız T ile ilgili Filtre Koyuyoruz. Veritabanı nesneleri imza sadece veritabani nesnelerimiz gelebilir demek ıstıyoruz.
    {
        //ilk kısım bir koşulu getirmek ıcın kullanılır ıkıncı kısımda ise sorguya dahil etmek ıcın kullanılır.
        //Bir Entity getiriyor bu metot 1-
        Task<T> GetAsync(Expression<Func<T,bool>> predicate,params Expression<Func<T, object>>[] includeProperties); //Bana kullanıcı getirir mısın bana bir tane makale getirir misin??
        //var kullanici = repository.GetAsync(k=>k.Id==15);

        //2- Bir listeye veya daha fazla entity getirmek ıstedıgımız zaman ise
        //Burada Makalelerin hepsini de yuklemek ısteyebılırız sadece C# makalelerini de yuklemek ısteyebılırız.
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate=null, params Expression<Func<T, object>>[] includeProperties);

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate); //Aynısı var mı Kontrolü yapmak üzere ?
        Task<int> CountAsync(Expression<Func<T, bool>> predicate=null); //Admin panelinde veri listeleme sayısal olarak



        //ŞUAN SOYUT HALDELER SOMUT HALLERİ EKLENECEK.


    }
}
