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
using ANTIsmoking.Options;

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
    
    Options op = new Options { botClient = botClient, update = update };
    op.DataSwitch();
    
    Console.WriteLine($"Received a '{messageText}' message in chat {message.Chat.Id}.");
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