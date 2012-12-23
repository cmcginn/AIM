using System;
using System.Configuration;
using System.Web;
using System.IO;

namespace AIM.Administration.Services
{
    public interface IFileService
    {
        string Save(HttpPostedFileBase fileBase, string relativeFilePath);
        string GetAbsolutePath(string path);
        string GetFilenameInStandardFormat(string prefix, DateTime timestamp, string extension);
    }

    public class FileService : IFileService
    {
        public string Save(HttpPostedFileBase fileBase, string relativeFilePath)
        {
            var filenameInStandardFormat = GetFilenameInStandardFormat(Path.GetFileNameWithoutExtension(fileBase.FileName), DateTime.Now, Path.GetExtension(fileBase.FileName));

            try
            {
                var filepath = GetAbsolutePath(Path.Combine(relativeFilePath, filenameInStandardFormat));
                fileBase.SaveAs(filepath);
                return filepath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Save(HttpPostedFileBase fileBase)
        {
            string relativeFilePath = ConfigurationManager.AppSettings["UploadPath"];
            return Save(fileBase, relativeFilePath);
        }

        public string GetAbsolutePath(string path)
        {
            return Path.Combine(GetRootPath(), path);
        }
        private string GetRootPath()
        {
            return HttpContext.Current.Server.MapPath("/");
        }
        public string GetFilenameInStandardFormat(string prefix, DateTime timestamp, string extension)
        {
            return string.Format("{0}.{1}{2}", prefix, timestamp.ToString("yyyyMMddHHmmss"), extension);
        }
    }
}

