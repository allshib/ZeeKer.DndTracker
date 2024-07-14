using DevExpress.ExpressApp.Core;
using DevExpress.ExpressApp.Security;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using Zeeker.DndTracker.Bot.WebApi.Types;
using ZeeKer.DndTracker.Module.BusinessObjects;

namespace Zeeker.DndTracker.Bot.WebApi.Services;

public class UpdateHandler : IUpdateHandler
{
    private static readonly InputPollOption[] PollOptions = ["Hello", "World!"];
    private const string usage = "<b><u>Меню</u></b>:";
    
    private static readonly List<List<InlineKeyboardButton>> DefaultMenuButtons =
        [
            [InlineKeyboardButton.WithCallbackData("Кампейн", BotStates.ChooseCampain)],
            [InlineKeyboardButton.WithCallbackData("Предметы", BotStates.Items)],
        ];

    private readonly ITelegramBotClient bot;
    private readonly ILogger<UpdateHandler> logger;
    private readonly INonSecuredObjectSpaceFactory objectSpaceFactory;


    public UpdateHandler(ITelegramBotClient bot, ILogger<UpdateHandler> logger, IServiceProvider serviceProvider)
    {
        this.bot = bot;
        this.logger = logger;
        var scope = serviceProvider.CreateScope();
        objectSpaceFactory = scope.ServiceProvider.GetRequiredService<INonSecuredObjectSpaceFactory>();
        
    }
    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await (update switch
        {
            { Message: { } message } => OnMessage(message),
            //{ EditedMessage: { } message } => OnMessage(message),
            { CallbackQuery: { } callbackQuery } => OnCallbackQuery(callbackQuery, cancellationToken),
            //{ InlineQuery: { } inlineQuery } => OnInlineQuery(inlineQuery),
            //{ ChosenInlineResult: { } chosenInlineResult } => OnChosenInlineResult(chosenInlineResult),
            //{ Poll: { } poll } => OnPoll(poll),
            //{ PollAnswer: { } pollAnswer } => OnPollAnswer(pollAnswer),
            // UpdateType.ChannelPost:
            // UpdateType.EditedChannelPost:
            // UpdateType.ShippingQuery:
            // UpdateType.PreCheckoutQuery:
            _ => UnknownUpdateHandlerAsync(update)
        });
    }
    public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken)
    {
        logger.LogInformation("HandleError: {Exception}", exception);
        // Cooldown in case of network connection error
        if (exception is RequestException)
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
    }
    private Task UnknownUpdateHandlerAsync(Update update)
    {
        logger.LogInformation("Unknown update type: {UpdateType}", update.Type);
        return Task.CompletedTask;
    }

    private async Task OnMessage(Message msg)
    {
        logger.LogInformation("Receive message type: {MessageType}", msg.Type);
        if (msg.Text is not { } messageText)
            return;

        Message? sentMessage = await (messageText.Split(' ')[0] switch
        {
            "/start" => OpenMenu(msg),
            "/menu" => OpenMenu(msg),
            _ => Task.FromResult(new Message())
        });
        logger.LogInformation("The message was sent with id: {SentMessageId}", sentMessage?.MessageId);
    }


    // Process Inline Keyboard callback data
    private async Task OnCallbackQuery(CallbackQuery callbackQuery, CancellationToken cancellationToken)
    {
        switch (callbackQuery.Data)
        {
            case BotStates.ChooseCampain:
                await GoToChooseCampain(callbackQuery, cancellationToken);
                break;
            case BotStates.MainMenu:
                await GoToMenu(callbackQuery, cancellationToken);
                break;
            default:
                logger.LogInformation("Received inline keyboard callback from: {CallbackQueryId}", callbackQuery.Id);
                await bot.AnswerCallbackQueryAsync(callbackQuery.Id, $"Received {callbackQuery.Data}");
                await bot.SendTextMessageAsync(callbackQuery.Message!.Chat, $"Received {callbackQuery.Data}");
                break;
        }


    }

    private async Task GoToMenu(CallbackQuery callbackQuery, CancellationToken cancellationToken)
    {
        await bot.EditMessageTextAsync(
                chatId: callbackQuery.Message.Chat.Id,
                messageId: callbackQuery.Message.MessageId,
                text: usage,
                parseMode: ParseMode.Html,
                replyMarkup: new InlineKeyboardMarkup(DefaultMenuButtons));
    }

    private async Task GoToChooseCampain(CallbackQuery callbackQuery, CancellationToken cancellationToken)
    {
        await bot.EditMessageTextAsync(
            chatId: callbackQuery.Message.Chat.Id, 
            messageId: callbackQuery.Message.MessageId,
            text: "Ваши Кампейны:",
            replyMarkup: new InlineKeyboardMarkup(GetCampainsMarkup()), 
            cancellationToken: cancellationToken);
        
    }

    private List<List<InlineKeyboardButton>> GetCampainsMarkup()
    {
        using var objectSpace = objectSpaceFactory.CreateNonSecuredObjectSpace(typeof(Campain));
        var campains = objectSpace.GetObjects<Campain>();
        var number = 1;
        var buttons = new List<List<InlineKeyboardButton>>();

        foreach (var campain in campains)
            buttons.Add([InlineKeyboardButton.WithCallbackData($"{number++}. {campain.Name}", campain.ID.ToString())]);
        buttons.Add([InlineKeyboardButton.WithCallbackData("Назад", BotStates.MainMenu)]);

        return buttons;
    }

    private async Task<Message> OpenMenu(Message msg)
    {
        
        return await bot.SendTextMessageAsync(msg.Chat, usage, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(DefaultMenuButtons));
    }
}