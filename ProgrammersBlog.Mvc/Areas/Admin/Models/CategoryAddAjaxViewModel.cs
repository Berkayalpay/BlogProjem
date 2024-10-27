using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class CategoryAddAjaxViewModel
    {
        //Sadece MVC katmanımızda kullanıcagımız model. DTO lar biraz daha generic bir yapidir.

        //Eklenen kategorinin verilerini içerir. ekleme formunun HTML yapisini da içerir.
        //Veriler burası ıcerısınde  JSON Formatinda Front-Ende geri döndürülür.
        public CategoryAddDto CategoryAddDto { get; set; } //Ekleme işlemi sırası form verileri
        public string CategoryAddPartial { get; set; }
        public CategoryDto CategoryDto { get; set; } //eklendikten sonraki kaydedilen kategori verileri

        //Kategori bilgilerini hem de formun html yapisini tek bir yerde paketlemiş oluruz.

    }
}
