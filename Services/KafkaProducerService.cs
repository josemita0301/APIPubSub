using Confluent.Kafka;

namespace IntegracionPubSub.Services
{
    public class KafkaProducerService
    {
        private readonly string _bootstrapServers = "localhost:9092"; // Dirección de Kafka

        public async Task SendMessageAsync(string message, string topic)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = _bootstrapServers,
                Debug = "broker,protocol"
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();
            try
            {
                var result = await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
                Console.WriteLine($"✅ Mensaje enviado: {result.TopicPartitionOffset}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error enviando mensaje: {ex.Message}");
            }
        }
    }
}
