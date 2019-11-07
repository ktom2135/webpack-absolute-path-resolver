using System.IO;

namespace resolver
{
    public class FileUtil
    {
        public static string[] GetAllFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        public static string GetConfigContent(string path)
        {
            return File.ReadAllText(path);
        }
    }
}