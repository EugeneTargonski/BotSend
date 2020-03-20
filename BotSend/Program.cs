using System;
using System.Configuration;
using System.Threading.Tasks;
using Telegram.Bot;

namespace BotSend
{
    static class Program
    {
        static async Task SendMessage(string message)
        {
            var AccessToken = ConfigurationManager.AppSettings.Get("AccessToken");
            var ChanellName = ConfigurationManager.AppSettings.Get("ChanellName");

            var bot = new TelegramBotClient(AccessToken);
            _ = bot.GetMeAsync().Result;
            await bot.SendTextMessageAsync(ChanellName, message);
        }
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a message text.");
            }
            else
            {
                var task = SendMessage(args[0]);
                task.Wait();
            }
        }
    }
}
