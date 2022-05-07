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

        //public ResultViewModel Success(string message="عملیات موفق")
        //{
        //    return new ResultViewModel()
        //    {
        //        Message = message,
        //        IsSuccess = true
        //    };
        //}

        //public ResultViewModel Failed(string message = "عملیات ناموفق")
        //{
        //    return new ResultViewModel()
        //    {
        //        Message = message,
        //        IsSuccess = true
        //    };
        //}
    }

  

}
