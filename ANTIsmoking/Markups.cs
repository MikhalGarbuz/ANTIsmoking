using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace ANTIsmoking
{
    internal class LocationsMarkups
    {
        public InlineKeyboardMarkup locationsMarkup = new(new[]
        {
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "НУЛП гуртожиток 8", callbackData: "8"),
                InlineKeyboardButton.WithCallbackData(text: "НУЛП гуртожиток 11", callbackData: "11"),
            },
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "НУЛП гуртожиток 14", callbackData: "14"),
                InlineKeyboardButton.WithCallbackData(text: "Львів вул. Бойчука 5", callbackData: "0"),
            }
        });
        
    }
}
