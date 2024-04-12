using ANTIsmoking.Data;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using MySql.Data.MySqlClient;


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

    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

    if (message.Text is "menu")
    {
        InlineKeyboardMarkup inlineKeyboard = new(new[]
        {
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "back", callbackData: "locations"),
            },
        });

        Message sentMessage = await botClient.SendTextMessageAsync(chatId,"Choose a response", replyMarkup: inlineKeyboard);
    }


    if (message.Text is "точки продажу")
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
            new KeyboardButton[] { "НУЛП гуртожиток 8", "НУЛП гуртожиток 11" },
            new KeyboardButton[] { "НУЛП гуртожиток 14", "Львів вул. Бойчука 5" }

        })
        {
            ResizeKeyboard = true
        };

        Message sentMessage = await botClient.SendTextMessageAsync(chatId, "Choose a response", replyMarkup: replyKeyboardMarkup);
    }////////////
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