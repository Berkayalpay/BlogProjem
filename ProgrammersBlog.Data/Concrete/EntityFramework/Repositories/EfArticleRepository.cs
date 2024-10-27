using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfArticleRepository : EfEntityRepositoryBase<Article>, IArticleRepository
    {
        //Dışarıdan DBContext alarak İçeriye inject yapiyoruz.
        public EfArticleRepository(DbContext context) : base(context)
        {
        }


    }
}
