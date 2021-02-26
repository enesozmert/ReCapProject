using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constant
{
    public static class FilePath
    {
        public static string _carImagePathNoName = StorageFilePath.GetPathCarImages();
        public static string _carImageNameDefault = "RentACarImageDefault.jpg";
    }
}
