using System.Threading.Tasks;
using SlackConnector.Models;

namespace SlackConnector.Client
{
    public interface IClient
    {
        Task SendMessage(Message message);
    }
}