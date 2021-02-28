using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Core.Utilities.File.FileUtilities;

namespace Core.Utilities.File.Concrete
{
    public class FormFileImageSave : ImageSaveBase
    {

        public override IEnumerable<string> Save(IFormFileProp formFileProp)
        {

            string[] result = new string[1];
            if (formFileProp.Name == null)
            {
                formFileProp.Name = GetFileName(formFileProp.OldPath);
            }

            string carImagePathAndName = formFileProp.NewPath + formFileProp.Name + FileExtension(formFileProp.FormFile.FileName);
            if (string.IsNullOrEmpty(formFileProp.FormFile.FileName) == false)
            {
                using (var stream = new FileStream(carImagePathAndName, FileMode.Create))
                    formFileProp.FormFile.CopyTo(stream);
            }
            result[0] = formFileProp.Name + FileExtension(formFileProp.FormFile.FileName);
            return result;
        }
    }
}
