
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
            HandleButtonClick += LogButtonClick;
        }
        #region EventLogs
        public void LogRequestCount(object? sender, UpdateArgs e, CancellationToken token)
        { Console.WriteLine($"CountRequest    chatId:\t{e.ChatId}\tcallback:{e.CallBackData}\tmessage:{e.Message}"); }
        public void LogRequestsHistory(object? sender, UpdateArgs e, CancellationToken token)
        { Console.WriteLine($"RequestHistory  chatId:\t{e.ChatId}\tcallback:{e.CallBackData}\tmessage:{e.Message}"); }
        public void LogUpdateTimeNews(object? sender, UpdateArgs e, CancellationToken token)
        { Console.WriteLine($"UpdateTimeNews  chatId:\t{e.ChatId}\tcallback:{e.CallBackData}\tmessage:{e.Message}"); }
        public void LogSearch(object? sender, UpdateArgs e, CancellationToken token)
        { Console.WriteLine($"Search          chatId:\t{e.ChatId}\tcallback:{e.CallBackData}\tmessage:{e.Message}"); }
        public void LogDefaultResponse(object? sender, UpdateArgs e, CancellationToken token)
        { Console.WriteLine($"DefaultResponse chatId:\t{e.ChatId}\tcallback:{e.CallBackData}\tmessage:{e.Message}"); }
        public void LogButtonClick(object? sender, UpdateArgs e, CancellationToken token)
        { Console.WriteLine($"ButtonClick     chatId:\t{e.ChatId}\tcallback:{e.CallBackData}\tmessage:{e.Message}"); }
        #endregion
    }
}
