using System.Collections.Generic;
using System.Linq;
using resolver;
using Xunit;

namespace resolver_test
{
    public class path_record_test
    {
        [Fact]
        public void should_generate_path_record_correctly()
        {
            Config config = new Config
            {
                Suffix = ".js",
                AliasMapping = new List<Mapping>
                {
                    new Mapping
                    {
                        Name = "@src",
                        Path = @"D:\git\myReactApp\src"
                    },
                    new Mapping
                    {
                        Name = "@comp",
                        Path = @"D:\git\myReactApp\comp"
                    }
                }
            };

            string[] fileNames = { @"D:\git\myReactApp\src\App.js", @"D:\git\myReactApp\comp\list.js" };

            List<AbsoluteRecord> absoluteRecords = AbsoluteRecordFactory.Create(config, fileNames);
            Assert.Equal(2, absoluteRecords.Count);
            Assert.Equal("App", absoluteRecords[0].Name);
            Assert.Equal("@src/App", absoluteRecords[0].AliasPath);
            Assert.Equal("list", absoluteRecords[1].Name);
            Assert.Equal("@comp/list", absoluteRecords[1].AliasPath);
        }
    }

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
                        AliasPath = aliasPath
                    });
                }
            }

            return result;
        }
    }

    public class AbsoluteRecord
    {
        public string Name { get; set; }
        public string AliasPath { get; set; }
    }
}