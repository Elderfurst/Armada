using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace CommandProcessor
{
    public static class Processor
    {
        [FunctionName("Processor")]
        public static void Run([ServiceBusTrigger("commands", Connection = "")]string myQueueItem, TraceWriter log)
        {
            log.Info($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
