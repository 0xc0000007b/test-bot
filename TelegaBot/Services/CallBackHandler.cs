using System;
using TelegaBot.utils;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegaBot.Services
{
    public  class CallBackHandler
    {
        
        public  int money = 0;
        public  int maxMoney = 999999999;
        
        public  string rnd = new Random().Next(0, 9).ToString();
        public  string[] sillyText = new text().LoremIpsum;
        int priceOfKremlin = 8000;
         int priceOfWhiteHouse = 2000;
        int priceOfShack = 100;    
        public  string[] papugs = new string[]
        {
            "https://i.pinimg.com/originals/33/01/90/33019060748c776717e80eee34b93c2b.jpg",
            "https://pressa.tv/uploads/posts/2019-07/1562054804_pressa_tv_memy-s-popugayami-04.jpeg",
            "https://www.meme-arsenal.com/memes/61ed3964506dc3746d0e9138c3a3bb9b.jpg",
            "https://i.pinimg.com/736x/e5/c4/47/e5c447bb82d9e15e627d4a550899f1d2.jpg",
            "https://medialeaks.ru/wp-content/uploads/2018/01/parrot-02-600x430.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR89XXe9HBBeNcfHhP-QEtTYI4F9VUcQbl8i9_Ny3ApE-ztarFj_oM0-S7TUGPyikp9UeI&usqp=CAU",
            "https://htstatic.imgsmail.ru/pic_original/bb949af07e04225e6f7b9b6b68a6017e/1668960/",
            "https://pressa.tv/uploads/posts/2019-07/1562054823_pressa_tv_memy-s-popugayami-02.jpg",
            "https://wowlol.ru/img4/c3d48ae832d775df22d47aba0baecf3c.jpg",
            "https://i.pinimg.com/originals/8e/89/f8/8e89f8c065049c418ef8323d4ecd4f0f.jpg",
            "https://i.pinimg.com/originals/3f/bc/83/3fbc8349d535dbf7802caacd169f0761.jpg",
            "https://cs12.pikabu.ru/post_img/big/2021/09/29/10/1632932059143344940.jpg",
            "https://cs14.pikabu.ru/post_img/big/2021/09/29/10/1632932051177036610.jpg",
            "https://i.pinimg.com/736x/e5/c4/47/e5c447bb82d9e15e627d4a550899f1d2.jpg",
            "https://cs13.pikabu.ru/post_img/big/2020/12/20/7/1608462443157490594.jpg",
            "https://www.meme-arsenal.com/memes/245b7a41e3677aa55cb877368858bd59.jpg",
            "https://64.media.tumblr.com/5fd2024042c4d64fc8f4f4375a131ce8/96545fe896df3169-84/s640x960/24ddd44e89961743fe4ebc1364fae78dca6eba12.jpg",
            "https://i.pinimg.com/236x/e8/4d/10/e84d109725f7eb9c4e2cbb65557b0067.jpg",
        };

        
            
        public async  void HandleQuery(ITelegramBotClient bot, CallbackQuery query)
        {
            
            switch (query.Data)
            {
                case "houses":
                    InlineKeyboardMarkup houses = new(new[]
                    {
                        new[]
                        {

                            InlineKeyboardButton.WithCallbackData("WhiteHouse", "buy_WhiteHouse"),
                            InlineKeyboardButton.WithCallbackData("Kremlin", "buy_Kremlin"),
                            InlineKeyboardButton.WithCallbackData("Shack", "buy_Shack"),
                        }
                    });
                    await bot.SendTextMessageAsync(query.Message.Chat.Id, "choose one optioon: ",
                        replyMarkup: houses
                    );
                    break;
                case "buy_house":
                case "buy_Shack":
                    if (money >= priceOfShack)
                    {

                        money -= priceOfShack;
                        await bot.SendTextMessageAsync(
                            query.Message.Chat.Id,
                            $"you successfully buy the Shack");
                        money += 10;
                            
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(query.Message.Chat.Id, "not enough money");
                    }

                    break;
                case "buy_Kremlin":
                    if (money >= priceOfKremlin)
                    {

                        money -= priceOfKremlin;
                        await bot.SendTextMessageAsync(
                            query.Message.Chat.Id,
                            $"you successfully buy the Kremlin");
                        money += 500;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(query.Message.Chat.Id, "not enough money");
                    }
                    break;
                case "buy_WhiteHouse":
                    if (money >= priceOfWhiteHouse)
                    {
                        money -= priceOfWhiteHouse;
                        await bot.SendTextMessageAsync(
                            query.Message.Chat.Id,
                            $"you successfully buy the White House");
                        money += 1000;
                            
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(query.Message.Chat.Id, "not enough money");
                    }
                    break;
                case "business":
                
                    InlineKeyboardMarkup businesses = new(new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Planet Saling", "planetselling"),
                        InlineKeyboardButton.WithCallbackData("Fast food", "fastfood"), 
                    });
                    await bot.SendTextMessageAsync(query.Message.Chat.Id, "choose one option: ",
                        replyMarkup: businesses);
                    break;
                
                case "buy_fastfood":
                    if (money >= priceOfKremlin)
                    {
                        money -= priceOfKremlin;
                        await bot.SendTextMessageAsync(
                            query.Message.Chat.Id,
                            $"you successfully buy the Fastfood restaurant");
                        money += 500;
                            
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(query.Message.Chat.Id, "not enough money");
                    }
                    break;
                case "buy_planetselling":
                    if (money >= priceOfWhiteHouse)
                    {
                        money -= priceOfWhiteHouse;
                        await bot.SendTextMessageAsync(
                            query.Message.Chat.Id,
                            $"you successfully buy the PlanetSelling business");
                        money += 1000;
                            
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(query.Message.Chat.Id, "not enough money");
                    }
                    break;
                case "buy_shop":
                    if (money >= priceOfShack)
                    {
                        money -= priceOfShack;
                        await bot.SendTextMessageAsync(
                            query.Message.Chat.Id,
                            $"you successfully buy the Shop");
                        money += 50;
                            
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(query.Message.Chat.Id, "not enough money");
                    }
                    break;
                //Game    
                case "answer_1":
                case "answer_2":
                case "answer_3":
                case "answer_4":
                case "answer_5":
                case "answer_6":
                case "answer_7":
                case "answer_8":
                case "answer_9":
                case "answer_0":
                    if (query.Data == "answer_" + rnd)
                    {
                        await bot.SendTextMessageAsync(query.Message.Chat.Id,
                            $"Congrats! you won, i will guess the {rnd} number. You're earned the 50$");
                        money += 50;
                        
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(query.Message.Chat.Id, $"you lose, i will guess the {rnd} number. try again by sending /game command.");
                        rnd = new Random().Next(0, 9).ToString();
                    }
                    break;
                case "cars":
                    
                        InlineKeyboardMarkup cars = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData("Bugatti", "buy_bugatti"),
                                InlineKeyboardButton.WithCallbackData("Mercedes", "buy_merc"),
                                InlineKeyboardButton.WithCallbackData("Moskvich", "buy_govno"),
                            }
                        });
                        await bot.SendTextMessageAsync(query.Message.Chat.Id, "choose one optioon: ",
                            replyMarkup: cars
                        );
                  
                        
                    break;
                //music
                case "Discography":
                    InlineKeyboardMarkup bands = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Rock", "Rock"),
                            InlineKeyboardButton.WithCallbackData("Pop", "Pop"),
                            InlineKeyboardButton.WithCallbackData("Rap", "Rap"),
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Reggie", "Reggie"),
                            InlineKeyboardButton.WithCallbackData("Funk", "Funk"),
                            InlineKeyboardButton.WithCallbackData("Phonk", "Phonk"),
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Jazz", "Jazz"),
                            InlineKeyboardButton.WithCallbackData("Dubstep", "Dubstep"),
                            InlineKeyboardButton.WithCallbackData("BeatBox", "Beatbox"),
                        },
                        new[]{
                            InlineKeyboardButton.WithCallbackData("Electronic", "Electronic"),
                            InlineKeyboardButton.WithCallbackData("Dance", "Dance"),
                        },
                    
                    });
                    await bot.SendTextMessageAsync(query.Message.Chat.Id, "choose one optioon: ",
                        replyMarkup: bands
                    );
                    break;
                case "Queen":
                    await bot.SendPhotoAsync(query.Message.Chat.Id, "https://darktorrent.ru/uploads/posts/2021-08/1628152113_3b27d45704afa96ee2fcd3af36d788ed1.jpg",
                        "<b>your link (!!!!FLAC!!!!): </b> <a href=\"https://darktorrent.ru/index.php?do=download&id=2311\">" +
                        "magnet</a>" + "\n" +
                        "<b>your link (!!!!MP3!!!!): </b> <a href=\"https://darktorrent.ru/index.php?do=download&id=2310\">" +
                        "magnet</a>", ParseMode.Html
                        );
                    break;
                case "Boston":
                    await bot.SendPhotoAsync(query.Message.Chat.Id, "http://www.metal-tracker.com/torrents/images/3096930.png",
                        "<b>your link (!!!!FLAC!!!!): </b> <a href=\"https://darktorrent.ru/index.php?do=download&id=1970\">" +
                        "magnet</a>" + "\n" +
                        "<b>your link (!!!!MP3!!!!): </b> <a href=\"https://darktorrent.ru/index.php?do=download&id=1969\">" +
                        "magnet</a>", ParseMode.Html);
                    break;
                case "Aerosmith":
                    await bot.SendPhotoAsync(query.Message.Chat.Id, "http://bestrockers.ru/_nw/7/s70725591.jpg",
                        "<b>your link (!!!!FLAC!!!!): </b> <a href=\"https://rutracker.org/forum/dl.php?t=4545243\">" +
                        "magnet</a>" + "\n" +
                        "<b>your link (!!!!MP3!!!!): </b> <a href=\"http://bestrockers.ru/MP3/A/aerosmith-polnaja_diskografija_mp33.torrent\">" +
                        "magnet</a>",
                        ParseMode.Html);
                    break;
                case "Who":
                    await bot.SendPhotoAsync(query.Message.Chat.Id, "http://bestrockers.ru/_nw/5/s99121516.jpg",
                        "<b>your link (!!!!FLAC!!!!): </b> <a href=\"http://bestrockers.ru/MP3/T/the_who-polnaja_diskflac-image.cue-tracks.cue-loss.torrent\">" +
                        "magnet</a>" + "\n" +
                        "<b>your link (!!!!MP3!!!!): </b> <a href=\"http://bestrockers.ru/MP3/T/rock-the_who-polnaja_diskografija-mp3-tracks-320_k.torrent\">" +
                        "magnet</a>",
                        ParseMode.Html);
                    break;
                case "Beatles":
                     
                    await bot.SendPhotoAsync(query.Message.Chat.Id, "https://losslessclub.com/attachs/torrent_35239_pic.jpg",
                        "<b>your link (!!!!FLAC!!!!): </b> <a href=\"https://darktorrent.ru/index.php?do=download&id=1973\">" +
                        "magnet</a>" + "\n" +
                        "<b>your link (!!!!MP3!!!!): </b> <a href=\"https://darktorrent.ru/index.php?do=download&id=1971\">" +
                        "magnet</a>",
                        ParseMode.Html);
                    break;
                
                case "Classical":
                    InlineKeyboardMarkup groups = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Queen", "Queen"),
                            InlineKeyboardButton.WithCallbackData("The Beatles", "Beatles"),
                            InlineKeyboardButton.WithCallbackData("The Who", "Who"),
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Aerosmith", "Aerosmith"),
                            InlineKeyboardButton.WithCallbackData("AC/DC", "ACDC"),
                            InlineKeyboardButton.WithCallbackData("Boston", "Boston"),
                        },
                    });
                    await bot.SendTextMessageAsync(query.Message.Chat.Id, "choose the group:", replyMarkup:groups);
                    break;
                case "Russian":
                    InlineKeyboardMarkup artists = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Alisa", "Alisa"),
                            InlineKeyboardButton.WithCallbackData("Kino", "Kino"),
                            InlineKeyboardButton.WithCallbackData("Nautilus Pompilius", "Nautilus"),
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Agatha Christie", "Agata"),
                            InlineKeyboardButton.WithCallbackData("Piknik", "Piknik"),
                            InlineKeyboardButton.WithCallbackData("Zemfira", "Zemfira"),
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("➤", "Next"),
                            InlineKeyboardButton.WithCallbackData("□", "home"),
                            InlineKeyboardButton.WithCallbackData("ᐊ", "prev"),
                        
                        }
                    });
                    await bot.SendTextMessageAsync(query.Message.Chat.Id, "Choose the group", replyMarkup: artists);
                    break;
                case "home":
                    InlineKeyboardMarkup artistsh = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Alisa", "Alisa"),
                            InlineKeyboardButton.WithCallbackData("Kino", "Kino"),
                            InlineKeyboardButton.WithCallbackData("Nautilus Pompilius", "Nautilus"),
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Agatha Christie", "Agata"),
                            InlineKeyboardButton.WithCallbackData("Piknik", "Piknik"),
                            InlineKeyboardButton.WithCallbackData("Zemfira", "Zemfira"),
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("➤", "Next"),
                            InlineKeyboardButton.WithCallbackData("□", "home"),
                            InlineKeyboardButton.WithCallbackData("ᐊ", "prev"),
                        
                        }
                    });
                    await bot.SendTextMessageAsync(query.Message.Chat.Id, "Choose the group", replyMarkup: artistsh);
                    break;
                case "prev":
                    
                    
                case "Next":
                    InlineKeyboardMarkup arts = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Aquarium", "Aquarium"),
                            InlineKeyboardButton.WithCallbackData("DDT", "DDT"),
                            InlineKeyboardButton.WithCallbackData("Picnic", "Picnic"),
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Splean", "Splean"),
                            InlineKeyboardButton.WithCallbackData("Chizh&Co", "Chizh"),
                            InlineKeyboardButton.WithCallbackData("Mashina Vremeni", "Mashina"),
                        },
                    });
                    await bot.SendTextMessageAsync(query.Message.Chat.Id, "Choose the group", replyMarkup: arts);
                    break;
                case "Alisa":
                    await bot.SendPhotoAsync(query.Message.Chat.Id, "https://darktorrent.ru/uploads/posts/2021-08/1628077417_cover.png",
                                            "<b>your link (!!!!FLAC!!!!): </b> <a href=\"https://rutracker.org/forum/dl.php?t=6224378\">" +
                                            "magnet</a>" + "\n" +
                                            "<b>your link (!!!!MP3!!!!): </b> <a href=\"http://mygamesrus.ru/engine/download.php?id=3014\">" +
                                            "magnet</a>",
                                            ParseMode.Html);
                                        break;
                case "Kino":
                    await bot.SendPhotoAsync(query.Message.Chat.Id, "https://darktorrent.ru/uploads/posts/2021-08/1628067110_6ef194cef5a1bf93ed1d87c7c095a4eb1.jpg",
                                            "<b>your link (!!!!FLAC!!!!): </b> <a href=\"https://darktorrent.ru/index.php?do=download&id=2207\">" +
                                            "magnet</a>" + "\n" +
                                            "<b>your link (!!!!MP3!!!!): </b> <a href=\"https://darktorrent.ru/index.php?do=download&id=2206\">" +
                                            "magnet</a>",
                                            ParseMode.Html);
                                        break;
                case "Aquarium":
                    await bot.SendPhotoAsync(query.Message.Chat.Id, "https://darktorrent.ru/uploads/posts/2021-08/1628251925_cover.jpg",
                                            "<b>your link (!!!!FLAC!!!!): </b> <a href=\"https://darktorrent.ru/index.php?do=download&id=2527\">" +
                                            "magnet</a>" + "\n" +
                                            "<b>your link (!!!!MP3!!!!): </b> <a href=\"https://darktorrent.ru/index.php?do=download&id=25266\">" +
                                            "magnet</a>",
                                            ParseMode.Html);
                                        break;
                case "Nautilus":
                    await bot.SendPhotoAsync(query.Message.Chat.Id, "https://darktorrent.ru/uploads/posts/2021-08/1628251082_cover.jpg",
                                            "<b>your link (!!!!FLAC!!!!): </b> <a href=\"https://darktorrent.ru/index.php?do=download&id=2519\">" +
                                            "magnet</a>" + "\n" +
                                            "<b>your link (!!!!MP3!!!!): </b> <a href=\"https://darktorrent.ru/index.php?do=download&id=2518\">" +
                                            "magnet</a>",
                                            ParseMode.Html);
                                        break;
                    
                case "Rock":
                    
                    InlineKeyboardMarkup dgenres = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Classical Rock", "Classical"),
                            InlineKeyboardButton.WithCallbackData("Russian Rock", "Russian"),
                            InlineKeyboardButton.WithCallbackData("Hard Rock", "Hard"),
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Punk", "Punk"),
                            InlineKeyboardButton.WithCallbackData("Metal", "Metal"),
                            InlineKeyboardButton.WithCallbackData("Alternative", "Alterbative"),
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("➤", "Next"),
                        
                        }
                    
                    });
                    await bot.SendTextMessageAsync(query.Message.Chat.Id, "choose the genre: ",
                        replyMarkup: dgenres
                    );
                    break;
                case "Albums":
                    InlineKeyboardMarkup albums = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Rock", "Rock"),
                            InlineKeyboardButton.WithCallbackData("Pop", "Pop"),
                            InlineKeyboardButton.WithCallbackData("Rap", "Rap"),
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Reggie", "Reggie"),
                            InlineKeyboardButton.WithCallbackData("Funk", "Funk"),
                            InlineKeyboardButton.WithCallbackData("Phonk", "Phonk"),
                        },
                   
                    });
                    await bot.SendTextMessageAsync(query.Message.Chat.Id, "choose one optioon: ",
                        replyMarkup: albums
                    );
                    break;
                case "Tracks":
                    InlineKeyboardMarkup genres = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Rock", "Rock"),
                            InlineKeyboardButton.WithCallbackData("Pop", "Pop"),
                            InlineKeyboardButton.WithCallbackData("Rap", "Rap"),
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Reggie", "Reggie"),
                            InlineKeyboardButton.WithCallbackData("Funk", "Funk"),
                            InlineKeyboardButton.WithCallbackData("Phonk", "Phonk"),
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Relax", "Relax"),
                        },
                    });
                    await bot.SendTextMessageAsync(query.Message.Chat.Id, "choose one optioon: ",
                        replyMarkup: genres
                    );
                    break;
                //cars
                case "buy_govno":
                    if (money >= priceOfShack)
                    {
                        money -= priceOfShack;
                        await bot.SendTextMessageAsync(
                            query.Message.Chat.Id,
                            $"you successfully buy the {query.Data}");
                        money += 10;
                    }
                    else
                    {
                        await bot.SendTextMessageAsync(query.Message.Chat.Id, "not enough money");

                    }
                    break;
                  case "buy_merc":
                      if (money >= priceOfKremlin)
                      {

                          money -= priceOfKremlin;
                          await bot.SendTextMessageAsync(
                              query.Message.Chat.Id,
                              $"you successfully buy the Mercedes");
                          money += 1000;

                      }
                      else
                      {
                          await bot.SendTextMessageAsync(query.Message.Chat.Id, "not enough money");

                      }

                      break;
                  case "buy_bugatti":
                      if (money >= priceOfWhiteHouse)
                      {

                          money -= priceOfWhiteHouse;
                          await bot.SendTextMessageAsync(
                              query.Message.Chat.Id,
                              $"you successfully buy the Bugatti");
                          money += 50000;

                      }
                      else
                      {
                          await bot.SendTextMessageAsync(query.Message.Chat.Id, "not enough money");

                      }

                      break;
                 
            }
        }
    }
}