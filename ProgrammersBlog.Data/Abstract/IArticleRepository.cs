using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IArticleRepository : IEntityRepository<Article>
    {
        // Article Add(Article article); alabilirdik generic repository ile bundan kacınıyoruz.
        //Hepsi için tek tek yazıcagımıza generic şekilde tek sefer yazıp her yerde kullanmaya basladık.
             
           

    }
}
