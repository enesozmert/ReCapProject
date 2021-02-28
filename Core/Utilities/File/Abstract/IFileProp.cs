using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.File
{
    public interface IFileProp
    {
        string Name { get; set; }
        string OldPath { get; set; }
        string NewPath { get; set; }
    }
}
