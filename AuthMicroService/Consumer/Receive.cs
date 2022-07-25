namespace AuthMicroService.Consumer;
 using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
class Receive
{
    public static void Receiver()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            Console.WriteLine("Waiting For Token Generation...");

            channel.QueueDeclare(queue: "auth",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            channel.BasicConsume(queue: "auth",
                                 autoAck: true,
                                 consumer: consumer);
            
            Console.ReadLine();
        }
    }
}
