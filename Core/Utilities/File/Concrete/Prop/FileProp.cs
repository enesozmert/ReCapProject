using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.File.Concrete
{
    public class FileProp : IFileProp
    {
        public string Name { get; set; }
        public string OldPath { get; set; }
        public string NewPath { get; set; }
    }
}
