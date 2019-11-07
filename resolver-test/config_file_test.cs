using System.IO;
using Newtonsoft.Json;
using resolver;
using Xunit;

namespace resolver_test
{
    public class config_file_test
    {
        [Fact]
        public void should_load_config_file_correctly()
        {
            var confileFilePath = "config.json";
            var fileContent = File.ReadAllText(confileFilePath);
            var config = JsonConvert.DeserializeObject<Config>(fileContent);
            Assert.Equal("C:\root", config.RootPath);
            Assert.Equal(".jsx", config.Suffix);
            Assert.Equal("import ", config.Prefix);
            Assert.Equal(2, config.AliasMapping.Count);
            Assert.Equal("@apps", config.AliasMapping[0].Name);
            Assert.Equal("C:\\root\\apps", config.AliasMapping[0].Path);
        }
    }
}