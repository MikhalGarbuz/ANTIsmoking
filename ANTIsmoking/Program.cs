using ANTIsmoking.Data;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using MySql.Data.MySqlClient;
using Telegram.Bot.Requests;
using ANTIsmoking.Markups;

var botClient = new TelegramBotClient("6436860979:AAHbR6jwJxZGtqXhbBh43VAlVTTzqoUppH8");

ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>()
};
botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions
);
var me = await botClient.GetMeAsync();
Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    if (update.Message is not { } message || message.Text is not { } messageText)
        return;

    var chatId = message.Chat.Id;

    ChDbContext chDbContext = new ChDbContext();
    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
    

    



}



Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}


//if ()
//{
//    InlineKeyboardMarkup inlineKeyboard = new(new[]
//    {
//        new []
//        {
//            InlineKeyboardButton.WithCallbackData(text: "НУЛП гуртожиток 8", callbackData: "8"),
//            InlineKeyboardButton.WithCallbackData(text: "НУЛП гуртожиток 11", callbackData: "11"),
//        },
//        new []
//        {
//            Inli  neKeyboardButton.WithCallbackData(text: "НУЛП гуртожиток 14", callbackData: "14"),
//            InlineKeyboardButton.WithCallbackData(text: "Львів вул. Бойчука 5", callbackData: "0"),
//        }
//    });

//    Message sentMessage = await botClient.SendTextMessageAsync(chatId, "Choose a response", replyMarkup: inlineKeyboard);

//}
//InlineKeyboardMarkup inlineKeyboard = new(new[]
//{
//    new []
//    {
//        InlineKeyboardButton.WithCallbackData(text: "1.1", callbackData: "11"),
//        InlineKeyboardButton.WithCallbackData(text: "1.2", callbackData: "12"),
//    },
//    new []
//    {
//        InlineKeyboardButton.WithCallbackData(text: "2.1", callbackData: "21"),
//        InlineKeyboardButton.WithCallbackData(text: "2.2", callbackData: "22"),
//    },
//});


//async Task Bot_OnCallbackQuery(ITelegramBotClient botClient, object sender, CallbackQuery e)
//{
//    var callbackData = e.Data;
//    var chatId = e.Message.Chat.Id;

//    switch (callbackData)
//    {
//        case "send_message":
//            await botClient.SendTextMessageAsync(chatId, "You clicked on Send Message.");
//            break;
//        case "main_menu":
//            await botClient.SendTextMessageAsync(chatId, "You clicked on Menu.");
//            break;
//        default:
//            break;
//    }

//    // Answer callback query
//    await botClient.AnswerCallbackQueryAsync(e.Id);
//}
    //if (message.Text is "menu")
    //{
    //    InlineKeyboardMarkup inlineKeyboard = new(new[]
    //    {
    //        new []
    //        {
    //            InlineKeyboardButton.WithCallbackData("Send Message", "send_message"),
    //            InlineKeyboardButton.WithCallbackData("Back to Main Menu", "main_menu")   
    //        },
    //    });

    //    Message sentMessage = await botClient.SendTextMessageAsync(chatId,"Choose a response", replyMarkup: inlineKeyboard);
    //}