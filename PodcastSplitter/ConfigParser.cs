using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;

namespace PodcastSplitter
{
    public static class ConfigParser
    {
        public static string Parse()
        {
            string path = ConfigPath.Path();
            var input = new StreamReader(path);
            Debug.WriteLine(string.Format("input is {0}", input));

            var yaml = new YamlStream();
            yaml.Load(input);

            return input.ReadToEnd();
        }
    }
}
