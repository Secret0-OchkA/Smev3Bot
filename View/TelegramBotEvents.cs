
namespace Smev_Bot.View
{
    internal partial class TelegramBotView
    {
        #region Events
        public delegate void BotDelegate(object? sender, UpdateArgs e, CancellationToken token);
        //commands 
        public event BotDelegate? HandleRequestCount;
        public event BotDelegate? HandleRequestsHistory;
        public event BotDelegate? HandleUpdateTimeNews;
        public event BotDelegate? HandleSearch;

        public event BotDelegate? DefaultResponse;

        public event BotDelegate? HandleButtonClick;
        #endregion
        void InitializeComponets()
        {
            HandleRequestCount += LogRequestCount;
            HandleRequestsHistory += LogRequestsHistory;
            HandleUpdateTimeNews += LogUpdateTimeNews;
            HandleSearch += LogSearch;
            DefaultResponse += LogDefaultResponse;
        }
        #region EventLogs
        public void LogRequestCount(object? sender, UpdateArgs e, CancellationToken token)
        { Console.WriteLine($"CountRequest\tchatId:\t{e.ChatId}"); }
        public void LogRequestsHistory(object? sender, UpdateArgs e, CancellationToken token)
        { Console.WriteLine($"RequestHistory\tchatId:\t{e.ChatId}"); }
        public void LogUpdateTimeNews(object? sender, UpdateArgs e, CancellationToken token)
        { Console.WriteLine($"UpdateTimeNews\tchatId:\t{e.ChatId}"); }
        public void LogSearch(object? sender, UpdateArgs e, CancellationToken token)
        { Console.WriteLine($"Search\tchatId:\t{e.ChatId}"); }
        public void LogDefaultResponse(object? sender, UpdateArgs e, CancellationToken token)
        { Console.WriteLine($"DefaultResponse\tchatId:\t{e.ChatId}"); }
        #endregion
    }
}
