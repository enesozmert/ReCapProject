using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.File
{
    public partial class FileUtilities : IFileUtilities
    {
        public static string FileExtension(string path)
        {
            string fileExtension = path.Substring(path.IndexOf("."), path.Length - path.IndexOf("."));
            return fileExtension;
        }
        public static string GetFileName(string path)
        {
            if (path.IndexOf(@"/") > -1)
            {
                return path.Substring(path.LastIndexOf(@"/"), path.Length - path.LastIndexOf(@"/"));
            }
            else if (path.IndexOf(@"\") > -1)
            {
                return path.Substring(path.LastIndexOf(@"\"), path.Length - path.LastIndexOf(@"\"));
            }
            return null;
        }
        public static bool CheckIfImageFile(string imagePath)
        {
            var extension = imagePath.Substring(imagePath.IndexOf("."), imagePath.Length - imagePath.IndexOf("."));

            bool result = (extension == ".jpg" || extension == ".jpeg" || extension == ".png");
            if (!result) return false;

            return true;
        }

        public static bool CheckIfImageFile(List<IFormFile> files)
        {
            //bool result = false;
            foreach (var file in files)
            {
                var extension = Path.GetExtension(file.FileName);

                bool result = (extension == ".jpg" || extension == ".jpeg" || extension == ".png");
                if (!result) return false;
            }
            return true;
        }

        public static bool CheckIfImageFile(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);

            bool result = (extension == ".jpg" || extension == ".jpeg" || extension == ".png");
            if (!result) return false;

            return true;
        }
        public static string NameGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
