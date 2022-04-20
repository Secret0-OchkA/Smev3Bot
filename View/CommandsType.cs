using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smev_Bot.View
{
    public class MakeCommand
    {
        public static CommandType StringToCommandType(string strCommand)
        {
            if (strCommand == "/number") return CommandType.RequestCount;
            else if (strCommand == "/requests") return CommandType.RequestHistory;
            else if (strCommand == "/update") return CommandType.UpdateTimeNews;
            else if (strCommand == "/search") return CommandType.Search;
            else return CommandType.UnknowCommand;
        }
    }
    public enum CommandType
    {
        UnknowCommand,
        RequestCount,
        RequestHistory,
        UpdateTimeNews,
        Search
    }
}
