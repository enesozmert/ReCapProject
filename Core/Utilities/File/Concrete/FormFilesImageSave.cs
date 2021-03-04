using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Core.Utilities.File.FileUtilities;

namespace Core.Utilities.File.Concrete
{
    public class FormFilesImageSave : ImageSaveBase
    {
        public override IEnumerable<string> Save(IFormFileProp formFileProp)
        {
            string[] result = new string[formFileProp.FormFiles.Length];
            for (int i = 0; i < formFileProp.FormFiles.Length; i++)
            {
                if (formFileProp.Name == null)
                {
                    formFileProp.Name = GetFileName(formFileProp.OldPath);
                }
                formFileProp.Name = FileUtilities.NameGuid();
                string carImagePathAndName = formFileProp.NewPath + formFileProp.Name + FileExtension(formFileProp.FormFiles[i].FileName);
                if (string.IsNullOrEmpty(formFileProp.FormFiles[i].FileName) == false)
                {
                    using (var stream = new FileStream(carImagePathAndName, FileMode.Create))
                        formFileProp.FormFiles[i].CopyTo(stream);
                }
                result[i] = formFileProp.Name + FileExtension(formFileProp.FormFiles[i].FileName);
            }
            return result;
        }
    }
}
