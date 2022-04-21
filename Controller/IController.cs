using Smev_Bot.View;
using Smev_Bot.Model;
using Telegram.Bot;

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
                replyMarkup: KeyBoards.TypeInformation(),
                cancellationToken: token);
        }

        async void ButtonClickEvent(object? sender, UpdateArgs e, CancellationToken token)
        {
            if (sender is TelegramBotClient client)
                await client.SendTextMessageAsync(
                chatId: e.ChatId,
                text: "в разработке",
                cancellationToken: token);
        }
    }
}
