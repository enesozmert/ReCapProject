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
                if (string.IsNullOrEmpty(formFileProp.OldPath) == false && System.IO.File.Exists(formFileProp.OldPath) == true)
                {
                    using (StreamWriter streamWriter = new StreamWriter(carImagePathAndName))
                    {
                        using (FileStream source = System.IO.File.Open(formFileProp.OldPath, FileMode.Open))
                        {
                            source.CopyTo(streamWriter.BaseStream);
                            source.Flush();
                            source.Dispose();
                            source.Close();
                        }
                        streamWriter.Flush();
                        streamWriter.Dispose();
                        streamWriter.Close();
                    }                
                    result[0] = formFileProp.Name + FileExtension(formFileProp.OldPath);                 
                }
        
                return result;
            }
        }
    }
}
