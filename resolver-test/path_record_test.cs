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
            string[] fileNames = {@"D:\git\myReactApp\src\App.js", @"D:\git\myReactApp\comp\list.js"};

            List<AbsoluteRecord> absoluteRecords = AbsoluteRecordFactory.Create(Fixtures.DefaultConfig, fileNames);
            Assert.Equal(2, absoluteRecords.Count);
            Assert.Equal("App", absoluteRecords[0].Name);
            Assert.Equal("@src/App", absoluteRecords[0].AliasPath);
            Assert.Equal("list", absoluteRecords[1].Name);
            Assert.Equal("@comp/list", absoluteRecords[1].AliasPath);
        }
        [Fact]
        public void should_no_generate_absolute_record_when_path_not_exist_in_config()
        {
            string pathNotExistInConfig = @"D:\git\myReactApp\not-exist\App.js";
            string[] fileNames =
            {
                @"D:\git\myReactApp\src\App.js", 
                @"D:\git\myReactApp\comp\list.js",
                pathNotExistInConfig,
            };

            List<AbsoluteRecord> absoluteRecords = AbsoluteRecordFactory.Create(Fixtures.DefaultConfig, fileNames);
            Assert.Equal(2, absoluteRecords.Count);
        }
    }
}