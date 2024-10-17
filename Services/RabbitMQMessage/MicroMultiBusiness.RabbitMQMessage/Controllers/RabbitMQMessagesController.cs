using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MicroMultiBusiness.RabbitMQMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQMessagesController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateMessage()
        {
            var connectionFactory = new ConnectionFactory() 
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "message-queue-2",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var messageContent = "Can Tokhay again was here!";

            var body = Encoding.UTF8.GetBytes(messageContent);

            channel.BasicPublish(exchange: "",
                                 routingKey: "message-queue-2",
                                 basicProperties: null,
                                 body: body);

            return Ok("Message On Queue");
        }

        private static string messageContent;
        [HttpGet]
        public IActionResult ReadMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                messageContent = Encoding.UTF8.GetString(body);
            };

            channel.BasicConsume(queue: "message-queue-2",
                                 autoAck: false,
                                 consumer: consumer);

            if (string.IsNullOrEmpty(messageContent))
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
            {
                return Ok(messageContent);
            }
        }
    }
}
