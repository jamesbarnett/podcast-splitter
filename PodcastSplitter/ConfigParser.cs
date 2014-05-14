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
        public static Dictionary<string, string> Parse()
        {
            string path = ConfigPath.Path();
            var input = new StreamReader(path);
            Debug.WriteLine(string.Format("input is {0}", input));

            var yaml = new YamlStream();
            yaml.Load(input);

            var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

            var config = new Dictionary<string, string>();

            foreach (var entry in mapping.Children)
            {
                Debug.WriteLine(string.Format("key: {0}, value", entry.Key, entry.Value));
                config.Add(entry.Key.ToString(), entry.Value.ToString());
            }

            return config;
        }
    }
}
