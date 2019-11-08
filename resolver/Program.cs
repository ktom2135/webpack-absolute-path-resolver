using System;
using System.IO;
using Newtonsoft.Json;

namespace resolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var confileFilePath = "config.json";
            var fileContent = FileUtil.GetConfigContent(confileFilePath);
            var config = JsonConvert.DeserializeObject<Config>(fileContent);
            var files = FileUtil.GetAllFiles(config);
        }
    }
}