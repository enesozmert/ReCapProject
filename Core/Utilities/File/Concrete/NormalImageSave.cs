using Core.Utilities.File.Concrete;
using System;
using System.Collections.Generic;
using System.IO;

namespace Core.Utilities.File
{
    public partial class FileUtilities
    {
        public class NormalImageSave : ImageSaveBase
        {
            public override IEnumerable<string> Save(IFormFileProp formFileProp)
            {
                string[] result = new string[1];
                if (formFileProp.Name == null)
                {
                    formFileProp.Name = GetFileName(formFileProp.OldPath);
                }

                string carImagePathAndName = formFileProp.NewPath + formFileProp.Name + FileExtension(formFileProp.OldPath);
                StreamWriter streamWriter = new StreamWriter(carImagePathAndName);
                if (string.IsNullOrEmpty(formFileProp.OldPath) == false)
                {
                    using (FileStream source = System.IO.File.Open(formFileProp.OldPath, FileMode.Open))
                    {
                        source.CopyToAsync(streamWriter.BaseStream);
                        source.Flush();
                        source.Dispose();
                    }
                    result[0] = formFileProp.Name + FileExtension(formFileProp.OldPath);
                }
                return result;
            }
        }
    }
}
