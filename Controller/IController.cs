using Smev_Bot.View;
using Smev_Bot.Model;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Smev_Bot.Model.SearchParamsCommand;
using SmevBot;

namespace Smev_Bot.Controllers
{
    internal interface IController
    {
        
    }

    enum ControllerStatus
    {
        Default,
        SearchParams,
        SearchName,
    }

    internal class Controller : IController
    {
        TelegramBotView view { get; set; }
        SearchParamsMaker SearchParamsMaker = new SearchParamsMaker();
        SearchParams searchParams { get; set; }
        ControllerStatus status { get; set; }

        public Controller(TelegramBotView botView)
        {
            view = botView;
            status = ControllerStatus.Default;
            InitializeComponets();
        }

        void InitializeComponets()
        {
            view.HandleRequestCount += NumberRequestsEvent;
            view.HandleRequestsHistory += RequestsEvent;
            view.HandleUpdateTimeNews += UpdateEvent;
            view.HandleSearch += SearchEvent;

            view.HandleButtonClick += ButtonClickEvent;
            view.DefaultResponse += TextMessage;
        }

        async void NumberRequestsEvent(object? sender, UpdateArgs e, CancellationToken token)
        {
            if (sender is TelegramBotClient client)
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
            {
                await client.SendTextMessageAsync(
                chatId: e.ChatId,
                text: "в разработке",
                cancellationToken: token);

                ParserWorker parserWorker = new ParserWorker(SmevBot.Smev3.Smev3Filter.GetDefault());
                var result = await parserWorker.GetDocs();
                foreach (var doc in result)
                {
                    //Console.WriteLine($"=============================={doc.Key}==============================");
                    foreach (var item in doc.Value)
                        await client.SendTextMessageAsync(
                        chatId: e.ChatId,
                        text: item.ToString(),
                        cancellationToken: token);
                }
            }
        }
        async void SearchEvent(object? sender, UpdateArgs e, CancellationToken token)
        {
            searchParams = new SearchParams();
            if (sender is TelegramBotClient client)
                await client.SendTextMessageAsync(
                chatId: e.ChatId,
                text: "A message with an inline keyboard markup",
                replyMarkup: KeyBoards.TypeSearch(),
                cancellationToken: token);
        }

        async void ButtonClickEvent(object? sender, UpdateArgs e, CancellationToken token)
        {
            if (sender is TelegramBotClient client)
            {
                var callbackPair = CallbackConverter.Convert(e.CallBackData);

                switch (callbackPair.Key)
                {
                    case KeyboardType.Information:
                        await UpdateKeyBoard(client, e, "Выберете среду сведений", KeyBoards.TypeEnvironment());
                        SearchParamsMaker.AddCommand(new SetZone(callbackPair.Value, searchParams));
                        break;
                    case KeyboardType.Environment:
                        await UpdateKeyBoard(client, e, "Выберете область применения сведений", KeyBoards.TypeApplication());
                        bool display = bool.Parse(callbackPair.Value);
                        SearchParamsMaker.AddCommand(new SetDisplayProdRequest(display, searchParams));
                        SearchParamsMaker.AddCommand(new SetDisplayTestRequest(!display, searchParams));
                        break;
                    case KeyboardType.Application:
                        SearchParamsMaker.AddCommand(new SetApplication(callbackPair.Value, searchParams));
                        SearchParamsMaker.ExecuteAll();
                        break;
                    case KeyboardType.Search:
                        if (bool.Parse(callbackPair.Value))
                        {
                            status = ControllerStatus.SearchName;
                            await client.SendTextMessageAsync(
                            chatId: e.ChatId,
                            text: "Введитие полное и частичное наименования сведения",
                            cancellationToken: token);
                        }
                        else
                        {
                            status = ControllerStatus.SearchParams;
                            await UpdateKeyBoard(client, e, "Выберете уровень сведений", KeyBoards.TypeInformation());
                        }
                        break;

                    case KeyboardType.UnknowType:
                    default:
                        break;
                }
            }
        }

        async Task GetData(object? sender, UpdateArgs e, CancellationToken token)
        {
            if (sender is TelegramBotClient client)
            {
                SmevBot.Smev3.Smev3Filter filter = new SmevBot.Smev3.Smev3Filter(version: searchParams.version,
                                                                                 id: searchParams.id,
                                                                                 apclication: searchParams.application,
                                                                                 zone: searchParams.zone,
                                                                                 name: searchParams.name,
                                                                                 displayTest: searchParams.displayTestRequest,
                                                                                 displayProd: searchParams.displayProdRequest,
                                                                                 filterParams: false);
                switch (status)
                {
                    case ControllerStatus.SearchParams: filter.FilterOnParametrs = true; break;
                    case ControllerStatus.SearchName: filter.FilterOnParametrs = false; break;
                }

                ParserWorker parser = new ParserWorker(filter);
                var result = await parser.GetDocs();
                foreach (var doc in result)
                {
                    foreach (var item in doc.Value)
                        await client.SendTextMessageAsync(
                        chatId: e.ChatId,
                        text: item.ToString(),
                        cancellationToken: token);
                }
            }
        }
        async void TextMessage(object? sender, UpdateArgs e, CancellationToken token)
        {
            switch (status)
            {
                case ControllerStatus.SearchParams:
                    break;
                case ControllerStatus.SearchName:
                    SearchParamsMaker.AddCommand(new SetName(e.Message, searchParams));
                    SearchParamsMaker.ExecuteAll();
                    await GetData(sender, e, token);
                    status = ControllerStatus.Default;
                    break;
                case ControllerStatus.Default: break;
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
