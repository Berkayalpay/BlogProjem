using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T>:IResult
    {
        //IDataResult veri taşıcaz bu veri User da Olabilir veya Kategori de olabilir bu nedenle Generic olmalı.

        //Farklı farklı propertyler tanımlamak yerıne cunku mesela ben bir kategori tasımak ısteyebılırım ya da IList ,Enumarable gibi bu nedenle burada <out T> diyoruz.

        public T Data { get;}  //new DataResult<Category>(ResultStatus.Success,category);
                              //new DataResult<IList<Category>>(ResultStatus.Success,categoryList);





    }
}
