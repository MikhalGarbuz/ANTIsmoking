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
        public async Task CumpusMurkup(ITelegramBotClient botClient, long chatId)
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
                    new KeyboardButton[] { "Гурт 3", "Гурт 8", "Гурт 11" },
                    new KeyboardButton[] { "Гурт 12", "Гурт 14", "Головна" }
                })
            {
                ResizeKeyboard = true
            };

            await botClient.SendTextMessageAsync(chatId, "Виберіть зручну для вас локацію:", replyMarkup: replyKeyboardMarkup);
        }
        public async Task StartMurkup(ITelegramBotClient botClient, long chatId)
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                    new KeyboardButton[] { "Переглянути наявність" }
                })
            {
                ResizeKeyboard = true
            };

            await botClient.SendTextMessageAsync(chatId, "Вітаю мій любий шанувальник куріння!!!", replyMarkup: replyKeyboardMarkup);
        }
    }
}
