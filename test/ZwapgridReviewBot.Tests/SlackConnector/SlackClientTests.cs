using System.Threading.Tasks;
using SlackConnector.Client;
using SlackConnector.Models;
using Xunit;

namespace ZwapgridReviewBot.Tests.SlackConnector
{
    public class SlackClientTests : TestsBase
    {
        [Fact]
        public async Task Check_SendMessage()
        {
            var slackClient = Resolve<ISlackClient>();
            var message = new Message
            {
                Text = "Test zwapgrid story review bot"
            };
            await slackClient.SendMessage(message);
        }
    }
}