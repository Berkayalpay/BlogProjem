using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Comment : EntityBase , IEntity
    {
        public string Text { get; set; }
        public int ArticleId { get; set; } //BÖYLE yazdıgımızda bunu bir de navigation propertysine ihtiyacımız var aşagıda :
        public Article Article { get; set; } //Navigation Property Bir Yorum Bir makaleye sahip olabilir.

    }
}
