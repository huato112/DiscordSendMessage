using Discord;
using Discord.Webhook;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace DiscordSendMessage
{
    class Program
    {
        DiscordWebhookClient _clientWebhook;
        string webhook = "https://discord.com/api/webhooks/918525358393921607/IddGiFQyaOG2E7jB4nqlbivzw1Yx6WD49uzTU0Opelg4fV3mVa9t5W24-j-HBweI3Ai8";

        DiscordSocketClient _client;
        ulong channelId = 918039910211022869;
        ulong guildId = 918039867202605066;
        String tokenBot = "Mzk5MjQ4NTI2OTQ2NTk4OTEy.WlEDKg.T8aAMUae2HVR0ngXdHnO_niSLHE";

        static void Main(string[] args)
        {
            new Program().Webhook().GetAwaiter().GetResult();
            new Program().RunAsync().GetAwaiter().GetResult();
        }

        public async Task Webhook()
        {
            _clientWebhook = new DiscordWebhookClient(webhook);
            _clientWebhook.SendMessageAsync("HelloWorld");
        }

        public async Task RunAsync()
        {

            _client = new DiscordSocketClient();

            await _client.LoginAsync(TokenType.Bot, tokenBot);
            await _client.StartAsync();

            // https://github.com/discord-net/Discord.Net/issues/1100
            _client.Ready += SendMessage;

            await Task.Delay(-1);
        }

        private async Task SendMessage()
        {
            var guild = _client.GetGuild(918039867202605066); // guild id
            var channel = guild.GetTextChannel(918039910211022869); // channel id
            await channel.SendMessageAsync("my_message");
            Environment.Exit(0);
        }
    }
}
