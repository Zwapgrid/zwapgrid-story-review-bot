using System;
using System.Threading.Tasks;
using Castle.Core.Logging;
using SlackAPI;
using SlackConnector.Configuration;
using Message = SlackConnector.Models.Message;

namespace SlackConnector.Client
{
    public interface ISlackClient
    {
        Task SendMessage(Message message, string channel = SlackConsts.DefaultChannel);
    }

    public class SlackClient : ISlackClient, ITransientDependency
    {
        private readonly SlackTaskClient _client;
        private readonly ILogger _logger;

        public SlackClient(ILogger logger)
        {
            _client = new SlackTaskClient(SlackConsts.Token);
            _logger = logger;
        }

        public async Task SendMessage(Message message, string channel = SlackConsts.DefaultChannel)
        {
            var response = await _client.PostMessageAsync(channel, message.Text);
            CheckResponse(response);
        }

        void CheckResponse(PostMessageResponse response)
        {
            if (!response.ok)
            {
                var message = $"Error: {response.error}, message: {response.message}";
                var ex = new Exception(message);
                _logger.Error(message);
                throw ex;
            }
        }
    }
}