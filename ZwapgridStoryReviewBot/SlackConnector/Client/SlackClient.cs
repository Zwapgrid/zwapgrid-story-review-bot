using System.Threading.Tasks;
using SlackAPI;
using Message = SlackConnector.Models.Message;

namespace SlackConnector.Client
{
    public class SlackClient : IClient
    {
        private readonly SlackTaskClient _client;

        public SlackClient()
        {
            _client = new SlackTaskClient(SlackConsts.Token);
        }

        public async Task SendMessage(Message message)
        {
            var response = await _client.PostMessageAsync("#general", message.Text);
        }
    }
}