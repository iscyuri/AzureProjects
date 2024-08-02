using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace MokKitchen.SampleFunction
{
    public class SampleServiceBusQueueTrigger
    {
        private readonly ILogger<SampleServiceBusQueueTrigger> _logger;

        public SampleServiceBusQueueTrigger(ILogger<SampleServiceBusQueueTrigger> logger)
        {
            _logger = logger;
        }

        [Function(nameof(SampleServiceBusQueueTrigger))]
        public async Task Run(
            [ServiceBusTrigger("myqueue", Connection = "AzureWebJobsStorage")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
