using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;
namespace Storage
{
    public class StorageFilePath
    {
        public static string GetPathCarImages()
        {
            string result = GetPathMain() + @"CarImages\";
            return result;
        }
        public static string GetPathMain()
        {
            var myType = typeof(StorageFilePath);
            string myTypeOfNamespace = myType.Namespace;
            string storageFilePathNoName = Directory.GetParent(System.IO.Path.GetDirectoryName(new System.Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath)).Parent.Parent.Parent.FullName;
            string result = storageFilePathNoName + @"\" + myTypeOfNamespace + @"\";
            return result;
        }
    }
}
