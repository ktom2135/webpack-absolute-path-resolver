using System.Collections.Generic;
using System.IO;

namespace resolver
{
    public class FileUtil
    {
        public static string[] GetAllFiles(Config config)
        {
//            var paths = Directory.GetDirectories(path, $"*.*", SearchOption.AllDirectories);
//            
//            List<string> result = new List<string>();
//
//            foreach (var path in paths)
//            {
            return Directory.GetFiles(config.RootPath, $"*{config.Suffix}", SearchOption.AllDirectories);
//            }
//            return result;
        }

        public static string GetConfigContent(string path)
        {
            return File.ReadAllText(path);
        }

        private static List<string> GetDirectories(string path)
        {
            List<string> result = new List<string>();
            if (Directory.Exists(path))
            {
                result.Add(path);
                var paths = Directory.GetDirectories(path);
                foreach (var subDir in paths)
                {
                    result.AddRange(GetDirectories(subDir));
                }
            }

            return result;
        }
    }
}