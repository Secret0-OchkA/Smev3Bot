
namespace Smev_Bot.View
{
    internal partial class TelegramBotView
    {
        #region Events
        public delegate void BotDelegate(object? sender, UpdateArgs e);
        //commands 
        public event BotDelegate? HandleRequestCount;
        public event BotDelegate? HandleRequestsHistory;
        public event BotDelegate? HandleUpdateTimeNews;
        public event BotDelegate? HandleSearch;

        public event BotDelegate? DefaultResponse;

        public event BotDelegate? HandleButtonClick;
        #endregion
    }
}
