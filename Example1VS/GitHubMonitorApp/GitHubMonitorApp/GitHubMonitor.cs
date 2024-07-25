using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace GitHubMonitorApp
{
    public class GitHubMonitor
    {
        private readonly ILogger<GitHubMonitor> _logger;

        public GitHubMonitor(ILogger<GitHubMonitor> logger)
        {
            _logger = logger;
        }

        [Function("GitHubMonitor")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("Ouer function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
