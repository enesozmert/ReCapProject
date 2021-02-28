using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.File
{
    public interface IFormFileProp : IFileProp
    {
        IFormFile[] FormFiles { get; set; }
        IFormFile FormFile { get; set; }
    }
}
