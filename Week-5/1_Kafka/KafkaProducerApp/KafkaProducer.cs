using Confluent.Kafka;
using System;
using System.Threading.Tasks;

public class KafkaProducer
{
    public static async Task Start()
    {
        var config=new ProducerConfig {BootstrapServers="localhost:9092" };

        using var producer=new ProducerBuilder<Null,string>(config).Build();

        Console.WriteLine("Enter messages (type 'exit' to stop):");

        while(true)
        {
            var input=Console.ReadLine();
            if (input.ToLower()=="exit") break;

            await producer.ProduceAsync("chat-topic",new Message<Null,string> {Value=input });
            Console.WriteLine($"[Sent]: {input}");
        }
    }
}