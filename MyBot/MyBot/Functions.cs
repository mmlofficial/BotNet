using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBot
{
    class Functions
    {
        public static void OpenLink(string URI)
        {
            if (URI.StartsWith("http"))
            {
                Thread thread = new Thread(() => { Process.Start(URI); });
                thread.Start();
            }
        }

        public static void DownloadExecute(string URI)
        {
            Thread thread = new Thread(() =>
            {
                string file_path = Web.DownloadFile(URI);
                Process.Start(file_path);
            });
            thread.Start();
        }

        public static void ShutdownComputer()
        {
            Thread thread = new Thread(() =>
            {
                Process.Start("cmd", "/c shutdown -s -f -t 00");
            });
            thread.Start();
        }
    }
}
