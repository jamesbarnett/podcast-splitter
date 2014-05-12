using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastSplitter
{
    public static class ConfigPath
    {
        public static string Path()
        {
#if DEBUG
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "config.yaml");
#else
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.yaml");
            
#endif
            if (!File.Exists(path))
            {
                // TODO: Load default config here
                throw new Exception("Configuration path not found");
            }

            return path;
        }
    }
}
