using Core.Utilities.File.Concrete;
using System.Collections.Generic;

namespace Core.Utilities.File
{
    public partial class FileUtilities
    {
        public abstract class ImageSaveBase : IImageSaveBase
        {
            public abstract IEnumerable<string> Save(IFormFileProp formFileProp);
        }
    }
}
