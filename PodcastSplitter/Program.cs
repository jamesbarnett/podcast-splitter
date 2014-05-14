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

            string options = string.Format("-q -f -t 4.0 -d C:\\PodcastSplitterOutput\\ -o @b_@t_@n {0}", 
                string.Format("\"{0}\"", podcasts));
            
            Process p = new Process();
            p.StartInfo.FileName = "mp3splt.exe";
            p.StartInfo.Arguments = options;
            p.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            p.Start();
            p.WaitForExit();

            Console.WriteLine("MP3 splitting complete. Press any key to continue...");
            Console.ReadKey();
        }
    }
}
