

namespace Smev_Bot.View
{
    public class UpdateArgs : EventArgs
    {
        public long ChatId { get; set; }
        public CommandType commandType { get; set; }
        public string CallBackData { get; set; }
        public string Message { get; set; }
        public UpdateArgs(long chatId, string callBackData = "", string message = "", CommandType commandType = CommandType.UnknowCommand)
        {
            this.ChatId = chatId;
            this.CallBackData = callBackData;
            this.Message = message;
        }
    }


}
