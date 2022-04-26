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
                    InlineKeyboardButton.WithCallbackData(text: "Межведомственное взаимодействие", callbackData: "3;Межведомственное взаимодействие"),
                    InlineKeyboardButton.WithCallbackData(text: "Базовый реестр", callbackData: "3;Базовый реестр"),
                    InlineKeyboardButton.WithCallbackData(text: "Приём заявлений с ЕПГУ", callbackData: "3;Приём заявлений с ЕПГУ"),
                    InlineKeyboardButton.WithCallbackData(text: "Прием заявлений с МФЦ", callbackData: "3;Прием заявлений с МФЦ"),
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

    public enum KeyboardType
    {
        UnknowType = 0,
        Information = 1,
        Environment = 2,
        Application = 3,
        Search = 4,
    }

    public class CallbackConverter
    {
        public static KeyValuePair<KeyboardType,string> Convert(string data)
        {
            string[] dataArr = data.Split(';');
            KeyboardType type = (KeyboardType)Enum.Parse(typeof(KeyboardType), dataArr[0]);
            return new KeyValuePair<KeyboardType, string>(type, dataArr[1]);
        }
    }
}
