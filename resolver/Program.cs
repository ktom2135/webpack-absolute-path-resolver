using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
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
            var records = AbsoluteRecordFactory.Create(config, files);
            var list = records.GroupBy(r => r.Name).Where(r => r.ToList().Count > 1).OrderByDescending(r => r.ToList().Count);
            foreach (var absoluteRecords in list)
            {
                foreach (var absoluteRecord in absoluteRecords)
                {
                    Console.WriteLine($"{absoluteRecord.FileFullPath}");
                }
            }
            
            FileResolvor.Resolve(config, files, records);
        }
    }

    public class FileResolvor
    {
        public static void Resolve(Config config, string[] files, List<AbsoluteRecord> records)
        {
            foreach (var file in files)
            {
                var fileContent = File.ReadAllLines(file);
                
                List<string> resolvedFileContent = new List<string>();
                foreach (var oneLine in fileContent)
                {
                    var oneLineContent = oneLine;
                    //import Component-one from '../common-components/component-one
                    if (oneLine.Trim().StartsWith(config.Prefix))
                    {
                        var componentName = GetComponentName(oneLine);
                        
                        var record = records.Find(r => r.Name == componentName);
                        if (record == null)
                        {
                            resolvedFileContent.Add(oneLine);
                            continue;
                        }

                        oneLineContent = Regex.Replace(oneLine, $@"'.*/{record.Name}'", $"'{record.AliasPath}'");
                        
                    }

                    resolvedFileContent.Add(oneLineContent);
                }
                
                File.WriteAllLines(file, resolvedFileContent);
            }
        }

        /// <summary>
        ///                    
        /// </summary>
        /// <param name="line">import Component-one from '../common-components/component-one'</param>
        /// <returns>component-one</returns>
        private static string GetComponentName(string line)
        {
            return line.Trim().Split(' ').Last().Split('/').Last().Replace("'", "").Replace(";", "");
        }
    }
}