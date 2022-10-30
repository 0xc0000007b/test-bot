using TelegaBot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegaBot.utils
{
    public class BankHandler
    {
        
        private CallBackHandler ch = new CallBackHandler();
        public  int cashInBank = 1000;
        public  double _maxCashInBank = 9999999999L; 

        public async void BankCommandHandler(ITelegramBotClient bot, Message msg)
        {
            switch (msg.Text)
            {
                case"/bank":
                    InlineKeyboardMarkup bank = new(new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Withdraw", "withdraw"),
                        InlineKeyboardButton.WithCallbackData("Deposit", "deposit"),
                    });
                    await bot.SendTextMessageAsync(msg.Chat.Id, "choose one option", replyMarkup: bank);
                    break;
                case "/bbalance":
                    await bot.SendTextMessageAsync(msg.Chat.Id, $"your balance is {cashInBank}");
                    break;
            }
            
        }
    
        public async void BankQueryHandle(ITelegramBotClient bot, CallbackQuery query)
        {
            switch (query.Data)
            {
                case "withdraw":
                    InlineKeyboardMarkup bank = new(new[]
                    {
                        InlineKeyboardButton.WithCallbackData("500$", "w500"),
                        InlineKeyboardButton.WithCallbackData("1000$", "1000"),
                    });
                    await bot.SendTextMessageAsync(query.Message.Chat.Id, "choose money amount to withdrawl", replyMarkup: bank);
                    break;
                case "w500":
                    if ( cashInBank >= 500)
                    {
                        cashInBank-= 500;
                        ch.money += 500;
                        await bot.SendTextMessageAsync(query.Message.Chat.Id, "successfully");
                        

                    }
                    else await bot.SendTextMessageAsync(query.Message.Chat.Id, "not enough money");
                    break;
                    case "w1000":
                    if (cashInBank >= 1000)
                    {
                        cashInBank -= 1000;
                        ch.money += 1000;
                        await bot.SendTextMessageAsync(query.Message.Chat.Id, "successfully");
                        

                    }
                    else await bot.SendTextMessageAsync(query.Message.Chat.Id, "not enough money");

                    break;
                
                case "deposit":
                    InlineKeyboardMarkup deposit = new(new[]
                    {
                        InlineKeyboardButton.WithCallbackData("500$", "d500"),
                        InlineKeyboardButton.WithCallbackData("1000$", "d1000"),
                    });
                    await bot.SendTextMessageAsync(query.Message.Chat.Id, "choose money amount to deposit", replyMarkup: deposit);
                    break;
                case "d500":
                    if (cashInBank >= 500)
                    {
                        ch.money -= 500;
                        cashInBank += 500;
                        await bot.SendTextMessageAsync(query.Message.Chat.Id, "successfully");
                        

                    }

                    break;
            }
        }
    }
    
}