using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class ImageUploadedDto
    {
        public string FullName { get; set; } // Resmi yükledikten sonra verdiğimiz isim
        public string OldName { get; set; } //Bize hangi isimle geldiği 
        public string Extension { get; set; }
        public string Path { get; set; }
        public string FolderName { get; set; } //Klasör hangi kalsöre yüklendıgı
        public long Size { get; set; }


        //Image helper resimlerle ilgili merkezi sistemimiz yani servisimiz.





    }
}
