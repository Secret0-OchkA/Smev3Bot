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
                    InlineKeyboardButton.WithCallbackData(text: "Региональный уровень", callbackData: "reg"),
                    InlineKeyboardButton.WithCallbackData(text: "Федеральный уровень", callbackData: "fed"),
                }
            });
        }
        public static InlineKeyboardMarkup TypeEnvironment()
        {
            return new(new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Продуктивная среда", callbackData: "true"),
                    InlineKeyboardButton.WithCallbackData(text: "Тестовая среда", callbackData: "false"),
                }
            });
        }
        public static InlineKeyboardMarkup TypeApplication()
        {
            return new(new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Межведомственное взаимодействие", callbackData: "1"),
                    InlineKeyboardButton.WithCallbackData(text: "Базовый реестр", callbackData: "2"),
                    InlineKeyboardButton.WithCallbackData(text: "Приём заявлений с ЕПГУ", callbackData: "3"),
                    InlineKeyboardButton.WithCallbackData(text: "Прием заявлений с МФЦ", callbackData: "4"),
                }
            });
        }
    }
}
