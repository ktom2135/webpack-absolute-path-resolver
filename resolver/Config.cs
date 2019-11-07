using System.Collections.Generic;

namespace resolver
{
    public class Config
    {
        public string RootPath { get; set; }
        public string Suffix { get; set; }
        public string Prefix { get; set; }
        public List<Mapping> AliasMapping { get; set; }
    }
}