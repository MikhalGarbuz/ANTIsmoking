using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ANTIsmoking.Data;
using ANTIsmoking.Markups;
using ANTIsmoking.Scan;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ANTIsmoking.Options
{
    public class Options
    {
        public Update update { get; set; }  
        public ITelegramBotClient botClient { get; set; }

        ChDbContext chDbContext = new ChDbContext();

        KeyboardMarkups kb = new KeyboardMarkups();
        public async Task DataSwitch()
        {
            var message = update.Message;
            var chatId = message.Chat.Id;
            switch (message.Text)
            {
                case "Гурт 3":
                    await botClient.SendTextMessageAsync(chatId, chDbContext.SelectComm(3));
                    break;
                case "Гурт 8":
                    await botClient.SendTextMessageAsync(chatId, chDbContext.SelectComm(8));
                    break;
                case "Гурт 11":
                    await botClient.SendTextMessageAsync(chatId, chDbContext.SelectComm(11));
                    break;
                case "Гурт 12":
                    await botClient.SendTextMessageAsync(chatId, chDbContext.SelectComm(12));
                    break;
                case "Гурт 14":
                    await botClient.SendTextMessageAsync(chatId, chDbContext.SelectComm(14));
                    break;
                case "Переглянути наявність":
                    kb.CumpusMurkup(botClient, chatId);
                    break;
                case "Головна":
                    kb.StartMurkup(botClient, chatId);
                    break;
                case "choksudo":
                    ScanToDb sc =new ScanToDb();
                    sc.TxtToDb();
                    break;
                case "sudochok":
                    chDbContext.DeleteComm();
                    break;
                //case "hui":


                default:
                    break;
            }
        }
        
        //public async Task AdminSwitch(ITelegramBotClient botClient, Update update)
        //{

        //}
    }
}
