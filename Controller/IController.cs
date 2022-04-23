using Smev_Bot.View;
using Smev_Bot.Model;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Smev_Bot.Controllers
{
    internal interface IController
    {
        
    }
    internal class Controller : IController
    {
        TelegramBotView view { get; set; }
        public Controller(TelegramBotView botView)
        {
            view = botView;
            InitializeComponets();
        }
        
        void InitializeComponets()
        {
            view.HandleRequestCount += NumberRequestsEvent;
            view.HandleRequestsHistory += RequestsEvent;
            view.HandleUpdateTimeNews += UpdateEvent;
            view.HandleSearch += SearchEvent;

            view.HandleButtonClick += ButtonClickEvent;
        }

        async void NumberRequestsEvent(object? sender, UpdateArgs e, CancellationToken token) 
        {
            if(sender is TelegramBotClient client)
            await client.SendTextMessageAsync(
            chatId: e.ChatId,
            text: "в разработке",
            cancellationToken: token);
        }
        async void RequestsEvent(object? sender, UpdateArgs e, CancellationToken token)
        {
            if (sender is TelegramBotClient client)
                await client.SendTextMessageAsync(
                chatId: e.ChatId,
                text: "в разработке",
                cancellationToken: token);
        }
        async void UpdateEvent(object? sender, UpdateArgs e, CancellationToken token)
        {
            if (sender is TelegramBotClient client)
                await client.SendTextMessageAsync(
                chatId: e.ChatId,
                text: "в разработке",
                cancellationToken: token);
        }
        async void SearchEvent(object? sender, UpdateArgs e, CancellationToken token) 
        {
            if (sender is TelegramBotClient client)
                await client.SendTextMessageAsync(
                chatId: e.ChatId,
                text: "A message with an inline keyboard markup",
                replyMarkup: KeyBoards.TypeSearch(),
                cancellationToken: token);
        }

        async void ButtonClickEvent(object? sender, UpdateArgs e, CancellationToken token)
        {
            if(sender is TelegramBotClient client)
            {
                var res = CallbackConverter.Convert(e.CallBackData);

                switch (res.Key)
                {
                    case CallBackType.Information:
                        await UpdateKeyBoard(client, e, "Выберете среду сведений", KeyBoards.TypeEnvironment());
                        break;
                    case CallBackType.Environment:
                        await UpdateKeyBoard(client, e, "Выберете область применения сведений", KeyBoards.TypeApplication());
                        break;
                    case CallBackType.Application:
                        await UpdateKeyBoard(client, e, "Выберете способ поиска", KeyBoards.TypeSearch());
                        break;
                    case CallBackType.Search:
                        await UpdateKeyBoard(client, e, "Выберете уровень сведений", KeyBoards.TypeInformation());
                        break;

                    case CallBackType.UnknowType:
                    default:
                        break;
                }
            }
        }


        async Task UpdateKeyBoard(object? sender, UpdateArgs e, string newHead, InlineKeyboardMarkup newKeyboard)
        {
            if (sender is TelegramBotClient client)
            {
                await client.EditMessageTextAsync(e.ChatId, e.MessageId, newHead);
                await client.EditMessageReplyMarkupAsync(e.ChatId, e.MessageId, newKeyboard);
            }
        }
    }
}
