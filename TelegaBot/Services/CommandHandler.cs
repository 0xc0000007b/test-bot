using System;
using File =  System.IO.File;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegaBot.Services
{
    
    public class CommandHandler
    {
        private CallBackHandler ch = new CallBackHandler();
        public static Random rndImg = new Random();
        public async void CommandResponseHandler(ITelegramBotClient bot, Message msg)
        {
            switch (msg.Text)
            {
                 case "/audio":
                    InlineKeyboardMarkup music = new(new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Discographies", "discography"),
                        InlineKeyboardButton.WithCallbackData("Albums", "albums"),
                        InlineKeyboardButton.WithCallbackData("Tracks", "tracks"),
                    });
                    await bot.SendTextMessageAsync(msg.Chat.Id, "Ok, choose one option: ", replyMarkup: music);
                    break;

                case "/shop":
                    InlineKeyboardMarkup shop = new(new[]
                        {
                            InlineKeyboardButton.WithCallbackData("business", "business"),
                            InlineKeyboardButton.WithCallbackData("cars", "cars"),
                            InlineKeyboardButton.WithCallbackData("homes", "house"),
                        });

                    await bot.SendTextMessageAsync(msg.Chat.Id, "choose what are you want to buy",
                        replyMarkup: shop);
                    break;

                case "/balance":
                    if (ch.money >= 0)
                    {
                        await bot.SendTextMessageAsync(msg.Chat.Id, $"You you have earned the {ch.money}$.");

                    }
                    else if (ch.money >= ch.maxMoney)
                    {

                        await bot.SendTextMessageAsync(msg.Chat.Id, $"You are earn max amount money.");
                    }

                    else if (ch.money <= 0)
                    {
                        await bot.SendTextMessageAsync(msg.Chat.Id, $"You are earn max amount money. your balance is equals {ch.money}");
                    }
                    break;

                case "/anek":
                    string[] anekdots = File.ReadAllLines("dummy.txt");
                    await bot.SendTextMessageAsync(msg.Chat.Id, $"{anekdots[new Random().Next(0, anekdots.Length)]}");
                    break;
                
                case "/generate":
                    await bot.SendTextMessageAsync(msg.Chat.Id, $"{ch.sillyText[new Random().Next(0, ch.sillyText.Length)]}");
                    break;

                case "/papug":
                    if (ch.money == 0)
                    {
                        await bot.SendTextMessageAsync(msg.Chat.Id, "earn your first money");
                    }
                    else
                    {
                        int s = rndImg.Next(ch.papugs.Length);
                        ch.money -= 10;
                        await bot.SendPhotoAsync(msg.Chat.Id, new InputOnlineFile(ch.papugs[s]));
                    }
                    break;

                case "/game":
                    InlineKeyboardMarkup keyboard = new(new[]
               {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("1", "answer_1"),
                        InlineKeyboardButton.WithCallbackData("2", "answer_2"),
                        InlineKeyboardButton.WithCallbackData("3", "answer_3"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("4", "answer_4"),
                        InlineKeyboardButton.WithCallbackData("5", "answer_5"),
                        InlineKeyboardButton.WithCallbackData("6", "answer_6"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("7", "answer_7"),
                        InlineKeyboardButton.WithCallbackData("8", "answer_8"),
                        InlineKeyboardButton.WithCallbackData("9", "answer_9"),
                    },
                    new []
                    {

                        InlineKeyboardButton.WithCallbackData("0", "answer_0"),
                    }

                });
                    await bot.SendTextMessageAsync(msg.Chat.Id, "Welcome to the game. i will randomize number for you. guess the number now",
                        replyMarkup: keyboard
                    );

                    ch.rnd = new Random().Next(0, 9).ToString();
                    break;

                case "/author":
                case "/info":
                    await bot.SendPhotoAsync(msg.Chat.Id, "https://tgrm.su/img/stickers/doctor_diy/1.jpg",
                    "<b>My author is: </b> <a href=\"https://t.me/NullRefExcept\">0xc000007b</a>",
                    ParseMode.Html);
                    break;

                case "/start":
                    ReplyKeyboardMarkup kb = new(
                    new[]
                {
                    new KeyboardButton[]{"/shop"},
                    new KeyboardButton[]{"/game"},
                    new KeyboardButton[]{"/papug"},
                    new KeyboardButton[]{"/balance"},
                    new KeyboardButton[]{"/audio"},

                });
                    await bot.SendTextMessageAsync(msg.Chat.Id,
                        $"Hello, {msg.Chat.FirstName}", replyMarkup: kb);
                    break;
                
            }
        }
    }
}