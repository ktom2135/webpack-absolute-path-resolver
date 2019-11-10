using System.Collections.Generic;
using resolver;

namespace resolver_test
{
    public class Fixtures
    {
        public static Config DefaultConfig = new Config
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
    }
}