using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter4
{
    public class TextConfigurationProvider:ConfigurationProvider
    {
        public string FilePath { get; set; }
        public TextConfigurationProvider(string path)
        {
            FilePath = path;
        }
        public override void Load()
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            using(FileStream fs =new FileStream(FilePath, FileMode.Open))
            {
                using(StreamReader sr=new StreamReader(fs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string key = line.Trim();
                        string value = sr.ReadLine();
                        data.Add(key, value);
                    }
                }
            }
            Data = data;
        }
    }
}
