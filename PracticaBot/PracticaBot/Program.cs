using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace PracticaBot
{
    
    class Program
    {
        private static readonly TelegramBotClient bot = new TelegramBotClient("983827301:AAFwH7Fc4Wf7H9m9uE0_C7zISwM1TfKymro");
        static string Text = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string Text1 = Console.ReadLine();
            Text = Text1;
            bot.OnMessage += Bot_OnMessage;
            var me = bot.GetMeAsync().Result;
            Console.Title = me.Username;

            bot.StartReceiving();
            Console.ReadLine();
            bot.StopReceiving();
        }



        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            
            Message Msg = e.Message;
            var Offset = 0;
            var Updates = await bot.GetUpdatesAsync(Offset);
            foreach (var update in Updates)
            {

            }
            if (Msg == null)
                return;
            if(Msg.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                await bot.SendTextMessageAsync(Msg.Chat.Id, $"Ваш текст: {Text}");
            }
        }
    }
}