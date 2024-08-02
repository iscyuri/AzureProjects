using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SampleQueueFunction
{
    public class Function5
    {
        private readonly ILogger<Function5> _logger;

        public Function5(ILogger<Function5> logger)
        {
            _logger = logger;
        }

        [Function(nameof(Function5))]
        public void Run([QueueTrigger("myqueue-items", Connection = "sampleConectionString")] QueueMessage message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
        }
    }
}
