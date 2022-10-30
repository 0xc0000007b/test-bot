using System;
using System.Threading;
using System.Threading.Tasks;
using TelegaBot.Services;
using TelegaBot.utils;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegaBot.Core
{
    public class Bot
    {
        private CallBackHandler qh = new CallBackHandler();
        private CommandHandler ch = new CommandHandler();
        private BankHandler bh = new BankHandler();
        
        public void Initialize()
        {
            ITelegramBotClient _client = new TelegramBotClient("");
            _client.StartReceiving(Update, Error);
            Console.ReadLine();
        }

        private Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        private async Task Update(ITelegramBotClient bot, Update u, CancellationToken arg3)
        {
            if (u.Type == UpdateType.Message)
            {
                await HandleMessage(bot, u.Message);
                
            }
            if (u.Type == UpdateType.CallbackQuery) 
            { 
                await HandleCallbackQuery(bot, u.CallbackQuery); 
                
                
            }
        }

        private async Task HandleCallbackQuery(ITelegramBotClient bot, CallbackQuery uCallbackQuery)
        {
             qh.HandleQuery(bot, uCallbackQuery);
             bh.BankQueryHandle(bot, uCallbackQuery);
        }

        private async Task HandleMessage(ITelegramBotClient bot, Message uMessage)
        {
            ch.CommandResponseHandler(bot, uMessage);
            bh.BankCommandHandler(bot, uMessage);
        }
    }
}