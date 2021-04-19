using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter4
{
    public class TextConfigurationSource : IConfigurationSource
    {
        public string FilePath { get; private set; }
        public TextConfigurationSource(string path)
        {
            FilePath = path;
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            string fpath = builder.GetFileProvider().GetFileInfo(FilePath).PhysicalPath;
            return new TextConfigurationProvider(fpath);
        }
    }
}
