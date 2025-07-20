using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Kafka Chat Application");
        Console.WriteLine("1. Start Producer");
        Console.WriteLine("2. Start Consumer");
        Console.Write("Choose option (1 or 2): ");
        var input=Console.ReadLine();

        switch(input)
        {
            case "1":
                KafkaProducer.Start().Wait();
                break;
            case "2":
                KafkaConsumer.Start();
                break;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }
}
