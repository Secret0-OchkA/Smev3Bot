

namespace Smev_Bot.View
{
    public class UpdateArgs : EventArgs
    {
        public long ChatId { get; set; }
        public int MessageId { get; set; }
        public CommandType commandType { get; set; }
        public string CallBackData { get; set; }
        public string Message { get; set; }
        public UpdateArgs(long chatId = -1, 
                          int messageId = -1,
                          string callBackData = "",
                          string message = "", 
                          CommandType commandType = CommandType.UnknowCommand)
        {
            this.ChatId = chatId;
            this.MessageId = messageId;
            this.CallBackData = callBackData;
            this.Message = message;
        }
    }


}
