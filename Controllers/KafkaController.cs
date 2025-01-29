using IntegracionPubSub.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntegracionPubSub.Controllers
{
    public class KafkaController : Controller
    {
        private readonly KafkaProducerService _producer;

        public KafkaController(KafkaProducerService producer)
        {
            _producer = producer;
        }

        [HttpPost("publicar-topic-1")]
        public async Task<IActionResult> PublicarMensajeTopic1([FromBody] string mensaje)
        {
            try
            {
                string topic1 = "topicApp1";
                await _producer.SendMessageAsync(mensaje, topic1);
                return Ok("📩 Mensaje enviado a Kafka.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }

        [HttpPost("publicar-topic-2")]
        public async Task<IActionResult> PublicarMensajeTopic2([FromBody] string mensaje)
        {
            try
            {
                string topic2 = "topicApp2";
                await _producer.SendMessageAsync(mensaje, topic2);
                return Ok("📩 Mensaje enviado a Kafka.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }
    }
}
