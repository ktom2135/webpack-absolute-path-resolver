using System.Collections.Generic;
using System.Linq;

namespace resolver
{
    public class AbsoluteRecordFactory
    {
        public static List<AbsoluteRecord> Create(Config config, string[] fileNames)
        {
            List<AbsoluteRecord> result = new List<AbsoluteRecord>();
            foreach (var fileName in fileNames)
            {
                var aliasMapping = config.AliasMapping.Find(am => fileName.Contains(am.Path));
                if (aliasMapping != null)
                {
                    var name = fileName.Split('\\').Last().Replace(config.Suffix, "");
                    var aliasPath = fileName
                        .Substring(0, fileName.Length - config.Suffix.Length)
                        .Replace(aliasMapping.Path, aliasMapping.Name)
                        .Replace(@"\", "/");
                    result.Add(new AbsoluteRecord
                    {
                        Name = name,
                        AliasPath = aliasPath,
                        FileFullPath = fileName
                    });
                }
            }

            return result;
        }
    }
}