﻿using DevExpress.ExpressApp.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;
using Zeeker.DndTracker.Bot.WebApi.Services;


namespace Zeeker.DndTracker.Bot.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BotController(IOptions<BotConfiguration> Config) : ControllerBase
{
    [HttpGet("setWebhook")]
    public async Task<string> SetWebHook([FromServices] ITelegramBotClient bot, CancellationToken ct)
    {
        var webhookUrl = Config.Value.BotWebhookUrl.AbsoluteUri;
        await bot.SetWebhookAsync(webhookUrl, allowedUpdates: [], secretToken: Config.Value.SecretToken, cancellationToken: ct);
        
        return $"Webhook set to {webhookUrl}";
    }

    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] Update update, 
        [FromServices] ITelegramBotClient bot, 
        [FromServices] UpdateHandler handleUpdateService, 
        [FromServices] INonSecuredObjectSpaceFactory objectSpaceFactory,
        CancellationToken ct)
    {
        if (Request.Headers["X-Telegram-Bot-Api-Secret-Token"] != Config.Value.SecretToken)
            return Forbid();
        try
        {
            
            await handleUpdateService.HandleUpdateAsync(bot, update, ct);
        }
        catch (Exception exception)
        {
            await handleUpdateService.HandleErrorAsync(bot, exception, Telegram.Bot.Polling.HandleErrorSource.HandleUpdateError, ct);
        }
        return Ok();
    }
}