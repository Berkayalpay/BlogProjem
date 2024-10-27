using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Concrete
{
    public class DataResult<T>:IDataResult<T>
    {
        //Sadece get değerleri var bizim bunları bir constructor aracılıgıyla almamız gerekıyor.
        public DataResult(ResultStatus resultStatus,T data)
        {
            ResultStatus = resultStatus; //DataResult oldugu ıcın data ve statü donuyoruz.
            Data = data;
        }
        //Data donmemız gerekmıyorsa zaten normal result ı kullanabılırız.

        public DataResult(ResultStatus resultStatus,string message, T data)
        {
            ResultStatus = resultStatus;
            Message = message; //DataResult oldugu ıcın data ve statü donuyoruz.
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, T data, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message; 
            Data = data;
            Exception= exception;
        }

        public ResultStatus ResultStatus { get;  }
        public string Message { get;  }
        public Exception Exception { get;  }
        public T Data { get;  }

        //Result olarak istersek kategori Listesi Kullanıcı listesi Rol listesi ihtiyaca gore Result Objesi ile beraber Veri de transfer ederek dönebilme fırsati sunuyor.
    }
}
