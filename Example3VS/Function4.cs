using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SampleQueueFunction
{
    public class Function4
    {
        private readonly ILogger<Function4> _logger;

        public Function4(ILogger<Function4> logger)
        {
            _logger = logger;
        }

        [Function(nameof(Function4))]
        public async Task Run([BlobTrigger("samples-workitems/{name}", Connection = "sampleConectionString")] Stream stream, string name)
        {
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
        }
    }
}
