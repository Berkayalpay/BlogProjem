using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Entities.Abstract
{
    public abstract class DtoGetBase
    {
        //Bu Base sınıfı Get işlemleri için kullanacagımızdan Get diyoruz.

        public virtual ResultStatus ResultStatus { get; set; } //Override etmek adına virtual

        //Bir Message alanı da eklersek Aslında GET İşlemlerini yaptıgımız tüm DTO sınıflarımıza bunu eklemıs oluruz.
        public virtual string Message { get; set; }


    }
}
