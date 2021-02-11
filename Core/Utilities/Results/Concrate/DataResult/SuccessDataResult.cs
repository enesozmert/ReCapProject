using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrate
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        //hepsi olan
        public SuccessDataResult(T data,string message):base(data,true,message)
        {
            
        }
        //mesajsız olan
        public SuccessDataResult(T data):base(data,true)
        {

        }
        public SuccessDataResult(string message):base(default,true,message)
        {

        }
        public SuccessDataResult():base(default,true)
        {

        }
    }
}
