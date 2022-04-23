using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace Smev_Bot.Model
{
    internal class KeyBoards
    {
        public static InlineKeyboardMarkup TypeInformation()
        {
            return new(new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Региональный уровень", callbackData: "1;reg"),
                },
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Федеральный уровень", callbackData: "1;fed"),
                }
            });
        }
        public static InlineKeyboardMarkup TypeEnvironment()
        {
            return new(new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Продуктивная среда", callbackData: "2;true"),
                    InlineKeyboardButton.WithCallbackData(text: "Тестовая среда", callbackData: "2;false"),
                }
            });
        }
        public static InlineKeyboardMarkup TypeApplication()
        {
            return new(new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Межведомственное взаимодействие", callbackData: "3;1"),
                    InlineKeyboardButton.WithCallbackData(text: "Базовый реестр", callbackData: "3;2"),
                    InlineKeyboardButton.WithCallbackData(text: "Приём заявлений с ЕПГУ", callbackData: "3;3"),
                    InlineKeyboardButton.WithCallbackData(text: "Прием заявлений с МФЦ", callbackData: "3;4"),
                }
            });
        }
        public static InlineKeyboardMarkup TypeSearch()
        {
            return new(new[]
{
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Поиск по наименованию", callbackData: "4;true"),
                    InlineKeyboardButton.WithCallbackData(text: "Поиск по параметрам", callbackData: "4;false"),
                }
            });
        }
    }

    public enum CallBackType
    {
        UnknowType,
        Information,
        Environment,
        Application,
        Search,
    }
    public class CallbackConverter
    {
        public static KeyValuePair<CallBackType,string> Convert(string data)
        {
            string[] dataArr = data.Split(';');
            CallBackType type = (CallBackType)Enum.Parse(typeof(CallBackType), dataArr[0]);
            return new KeyValuePair<CallBackType, string>(type, dataArr[1]);
        }
    }
}
