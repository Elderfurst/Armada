using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Functions
{
    public static class ActionProcessor
    {
        [FunctionName("ActionProcessor")]
        public static void Run([ServiceBusTrigger("actions", Connection = "")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
