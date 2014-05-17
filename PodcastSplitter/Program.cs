using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigParser.Parse();
            string podcasts = Path.Combine(config["root"], config["podcast"]);

            Debug.WriteLine(string.Format("mp3split_split_options: {0}", config["mp3split_split_options"]));

            string options = string.Format("{0} -d {1} -o {2} {3}",
                config["mp3split_split_options"],
                config["outputdir"], 
                config["mp3split_output_options"],
                string.Format("\"{0}\"", podcasts));
            
            Process p = new Process();
            p.StartInfo.FileName = config["mp3split"];
            p.StartInfo.Arguments = options;
            p.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            p.Start();
            p.WaitForExit();

            Console.WriteLine("MP3 splitting complete. Press any key to continue...");
            Console.ReadKey();
        }
    }
}
