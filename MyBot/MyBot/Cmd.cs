using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyBot
{
    class Cmd
    {
        public string ComType { get; private set; }
        public string ComContent { get; private set; }

        public Cmd(string input_content)
        {
            string[] cmd_cnt = Regex.Split(input_content, Configs.splitter);

            ComType = cmd_cnt[0];
            ComContent = cmd_cnt[1];
        }
    }
}
