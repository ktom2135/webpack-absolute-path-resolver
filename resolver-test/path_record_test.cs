using System.Collections.Generic;
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
                Suffix = ".txt",
                AliasMapping = new List<Mapping>
                {
                    new Mapping
                    {
                        AliasName = "@A",
                        MatchPath = "pathA"
                    },
                    new Mapping
                    {
                        AliasName = "@B",
                        MatchPath = "PathB"
                    }
                }
            };

            string[] fileNames = {"pathA/file-a.txt", "PathB/file-b.txt"};

            List<AbsoluteRecord> absoluteRecords = AbsoluteRecordFactory.Create(config, fileNames);
            Assert.Equal(2, absoluteRecords.Count);
            Assert.Equal("file-a", absoluteRecords[0].Name);
            Assert.Equal("@A/file-a", absoluteRecords[0].AliasPath);
            Assert.Equal("file-b", absoluteRecords[1].Name);
            Assert.Equal("@B/file-a", absoluteRecords[1].AliasPath);
        }
    }

    public class AbsoluteRecordFactory
    {
        public static List<AbsoluteRecord> Create(Config config, string[] fileNames)
        {
            List<AbsoluteRecord> result = new List<AbsoluteRecord>();
            foreach (var fileName in fileNames)
            {
                var record = new AbsoluteRecord();
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