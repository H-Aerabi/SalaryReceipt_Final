using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Application.Contract.common
{
    public class ResultViewModel<T> : ResultViewModel
    {
        
        public T Result { get; set; }
        
    }

    public class ResultViewModel
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public ResultViewModel Success(string message="عملیات با موفقیت انجام شد ")
        {
            Message = message;
            IsSuccess = true;
            return this;
        }
        public ResultViewModel Failed(string message="عملیات ناموفق")
        {
            Message = message;
            IsSuccess = false;
            return this;
        }
    }

  

}
