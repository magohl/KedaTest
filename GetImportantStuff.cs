using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Kramerica.Functions
{
    public static class GetImportantStuff
    {
        [FunctionName("GetImportantStuff")]
        public static void Run([KafkaTrigger(
            "kafka.kafka.svc.cluster.local:9092", "important-stuff",
            ConsumerGroup="test-consumer-group",
            Protocol=BrokerProtocol.Plaintext)] KafkaEventData<string>[] kafkaEvents, ILogger logger)
        {
            logger.LogInformation($"Kafka event triggered! The important message received was '{kafkaEvents[0].Value}'");
        }
    }
}


