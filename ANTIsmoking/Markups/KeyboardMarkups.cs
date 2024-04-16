using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace ANTIsmoking.Markups
{
    public class KeyboardMarkups
    {
        public async Task CumpusMurkup(ITelegramBotClient botClient, Message message)
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
                    new KeyboardButton[] { "НУЛП гуртожиток 3", "НУЛП гуртожиток 8", "НУЛП гуртожиток 11" },
                    new KeyboardButton[] { "НУЛП гуртожиток 12", "НУЛП гуртожиток 14", "" }
                })
            {
                ResizeKeyboard = true
            };

            await botClient.SendTextMessageAsync(message.MessageId, "Виберіть зручну для вас локацію:", replyMarkup: replyKeyboardMarkup);
        }
        public async Task StartMurkup(ITelegramBotClient botClient, Message message)
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                    new KeyboardButton[] { "Переглянути наявність" }
                })
            {
                ResizeKeyboard = true
            };

            await botClient.SendTextMessageAsync(message.MessageId, "Choose a response", replyMarkup: replyKeyboardMarkup);
        }
    }
}
