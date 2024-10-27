using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        //Ornegin Article sınıfında bunu override yaparak CreatedDate = new DateTime(2020.01.01);
        //Override edilmesini istiyorsak bunları virtual olarak işaretlemeliyiz.
        public virtual int Id { get; set; } //PK
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        //Silinmemiş değerleri getirmemiz gerektiğinden dolayı
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual string ModifiedByName { get; set; } = "Admin";
        public virtual string Note { get; set; }



    }
}
