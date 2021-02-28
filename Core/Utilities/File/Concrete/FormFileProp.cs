using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.File.Concrete
{
    public class FormFileProp : IFormFileProp
    {
        public IFormFile[] FormFiles { get; set; }
        public IFormFile FormFile { get; set; }
        public string Name { get; set; }
        public string OldPath { get; set; }
        public string NewPath { get; set; }
    }
}
