namespace ZwapReviewBot.Web.Services
{
    public interface IPivotalWebhookProcessor
    {
        
    }
    
    public class PivotalWebhookProcessor : IPivotalWebhookProcessor
    {
        private const string WebhookKind = "review_update_activity";
    }
}