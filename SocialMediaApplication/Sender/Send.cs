namespace SocialMediaApplication.Sender;
using System;
using RabbitMQ.Client;
using System.Text;
class Send
{
    public static void Producer(string message)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            Console.WriteLine("Intializing Login!");
            Console.WriteLine("Generating Token");

            channel.QueueDeclare(queue: "auth",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "",
                                 routingKey: "auth",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(message);
            Console.WriteLine("Token generated Successfully");

        }

    }
}
