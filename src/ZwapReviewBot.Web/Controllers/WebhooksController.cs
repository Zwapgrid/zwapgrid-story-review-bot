using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PivotalTrackerConnector;
using PivotalTrackerConnector.Models.Webhooks;

namespace ZwapReviewBot.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebhooksController : ControllerBase
    {
        private readonly ILogger<WebhooksController> _logger;

        private const int ReviewId = 5692600;
        
        public WebhooksController(ILogger<WebhooksController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("pivotal")]
        public async Task<IActionResult> HandlePivotalWebhook(WebhookData webhookData)
        {
            var data = webhookData;
            var pivotal = new PivotalTracker("d1a787245f2e520a7ffe765329aa7e0c", 2438879);
            var storyId = data.Changes.Where(x => x.Kind == "story").Select(x => x.Id).Single();

            var reviews = await pivotal.Tracker.GetStoryReviewsByIdAsync(2438879, storyId.Value);

            var projectReviews = reviews.Where(x => x.ReviewTypeId == 5692600).ToList();
            var isAnyProjectReviews = projectReviews.Any();
            
            _logger.Log(LogLevel.Debug, JsonConvert.SerializeObject(new {projectReviews, isAnyProjectReviews}));
            
            return Ok();
        }
    }
}
