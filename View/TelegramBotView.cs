
using Smev_Bot.Controllers;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


namespace Smev_Bot.View
{
    internal partial class TelegramBotView
    {
        readonly TelegramBotClient _client;
        public TelegramBotClient Client { get { return _client; } }
        IController _controller;
        CancellationTokenSource _tokenSource;
        string _botName;
        public string BotName { get { return _botName; } }

        public TelegramBotView(BotConfiguration config)
        {
            _client = new TelegramBotClient(config.key);
            _tokenSource = new CancellationTokenSource();
            _controller = new Controller(this);
            _botName = config.name;
            InitializeComponets();
        }

        public async Task Start()
        {
            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // receive all update types
            };
            _client.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken: _tokenSource.Token);

            var me = await _client.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();
        }
        public void Stop()
        {
            // Send cancellation request to stop bot
            _tokenSource.Cancel();
        }

        async Task HandleUpdateAsync(ITelegramBotClient clietn, Update update, CancellationToken cancellationToken)
        {
            UpdateArgs updateArgs = new();
            if (update.Type == UpdateType.Message)
            {
                updateArgs.ChatId = update.Message.Chat.Id;
                updateArgs.Message = update.Message.Text;
                updateArgs.MessageId = update.Message.MessageId;

                Regex commandRegex = new Regex(@"^\/\w+$");
                if (commandRegex.IsMatch(updateArgs.Message))
                    updateArgs.commandType = MakeCommand.StringToCommandType(update.Message.Text);
            }
            else if (update.Type == UpdateType.CallbackQuery)
            {
                updateArgs.ChatId = update.CallbackQuery.Message.Chat.Id;
                updateArgs.CallBackData = update.CallbackQuery.Data;
                updateArgs.MessageId = update.CallbackQuery.Message.MessageId;
            }
            else return;
           
            switch (update.Type)
            {
                case UpdateType.Message:
                    switch (updateArgs.commandType)
                    {
                        case CommandType.RequestCount: HandleRequestCount?.Invoke(_client, updateArgs, cancellationToken); break;
                        case CommandType.RequestHistory: HandleRequestsHistory?.Invoke(_client, updateArgs, cancellationToken); break;
                        case CommandType.UpdateTimeNews: HandleUpdateTimeNews?.Invoke(_client, updateArgs, cancellationToken); break;
                        case CommandType.Search: HandleSearch?.Invoke(_client, updateArgs, cancellationToken); break;

                        case CommandType.UnknowCommand: DefaultResponse?.Invoke(_client, updateArgs, cancellationToken); break;
                    }

                    break;
                case UpdateType.CallbackQuery:
                    HandleButtonClick?.Invoke(_client, updateArgs, cancellationToken);
                    break;

                default: DefaultResponse?.Invoke(_client, updateArgs, cancellationToken); break;
            }

            
        }
        private Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}

