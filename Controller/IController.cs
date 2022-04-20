using Smev_Bot.View;

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

        void NumberRequestsEvent(object? sender, UpdateArgs e) { throw new NotImplementedException(); }
        void RequestsEvent(object? sender, UpdateArgs e) { throw new NotImplementedException(); }
        void UpdateEvent(object? sender, UpdateArgs e) { throw new NotImplementedException(); }
        void SearchEvent(object? sender, UpdateArgs e) { throw new NotImplementedException(); }

        void ButtonClickEvent(object? sender, UpdateArgs e) { throw new NotImplementedException(); }
    }
}
