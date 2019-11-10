using System.Collections.Generic;
using System.IO;
using System.Net;
using resolver;
using Xunit;

namespace resolver_test
{
    public class file_processor_test
    {
        [Fact]
        public void should_process_content_correctly()
        {
            string[] fileContent =
            {
                @"import Component-one from '../common-components/component-one"
            };


            Config config = new Config
            {
                Prefix = "import",
                AliasMapping = new List<Mapping>
                {
                    new Mapping
                    {
                        Name = "@apps",
                        Path = "C:\\root\\apps"
                    },
                    new Mapping
                    {
                        Name = "@comp",
                        Path = "C:\\root\\comp"
                    },
                }
            };
        }
    }
}