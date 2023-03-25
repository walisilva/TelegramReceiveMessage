using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram
{
    internal class Program
    {
        static TelegramBotClient Bot = new TelegramBotClient("YOUR_API_KEY_HERE!");
        static void Main(string[] args)
        {
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new UpdateType[]
                {
                    UpdateType.Message,
                    UpdateType.EditedMessage,
                }
            };

            Bot.StartReceiving(updateHandler, ErrorHandler, receiverOptions);
            
            Console.ReadLine();
        }

        private static Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        private static async Task updateHandler(ITelegramBotClient bot, Update update, CancellationToken arg3)
        {
            if(update.Type == UpdateType.Message)
            {
                if(update.Message.Type == MessageType.Text)
                {
                    var text = update.Message.Text;
                    var id = update.Message.Chat.Id;
                    string? username = update.Message.Chat.Username;

                    Console.WriteLine($"{username} | {id} | {text}");
                }
            }
        }
    }
}