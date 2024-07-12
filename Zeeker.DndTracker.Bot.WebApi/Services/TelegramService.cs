using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ZeeKer.DndTracker.WebApi.Services
{
    public class TelegramService : BackgroundService
    {
        private readonly TelegramBotClient bot;
        private readonly HttpClient client = new HttpClient();

        public TelegramService()
        {
            var bot = new TelegramBotClient("6944480659:AAHg0p6MkaSWKcN1X5oDxdwDAL_UhoAwMcU", client); 
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var options = new Telegram.Bot.Polling.ReceiverOptions();




            //bot.StartReceiving();

            var me = await bot.GetMeAsync(stoppingToken);
        }
        

        private async Task OnUpdate(ITelegramBotClient bot, Update update, CancellationToken ct)
        {
            if (update.Message is null) return;         // we want only updates about new Message
            if (update.Message.Text is null) return;    // we want only updates about new Text Message
            var msg = update.Message;
            Console.WriteLine($"Received message '{msg.Text}' in {msg.Chat}");
            
            await bot.SendTextMessageAsync(msg.Chat, $"{msg.From} said: {msg.Text}");
        }

        //private async Task OnUpdate(ITelegramBotClient bot, Update update, CancellationToken ct)
        //{
        //    if (update.Message is null) return;         // we want only updates about new Message
        //    if (update.Message.Text is null) return;    // we want only updates about new Text Message
        //    var msg = update.Message;
        //    Console.WriteLine($"Received message '{msg.Text}' in {msg.Chat}");

        //    await bot.SendTextMessageAsync(msg.Chat, $"{msg.From} said: {msg.Text}");
        //}

    }
}
