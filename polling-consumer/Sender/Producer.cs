using System;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;
using SimpleMessaging;

namespace Sender
{
    class Producer
    {
        static void Main(string[] args)
        {
            using (var channel = new DataTypeChannelProducer<Greeting>((greeting) => JsonConvert.SerializeObject(greeting)))
            {
                for (int i = 0; i < 100; i++)
                {
                    var greeting = new Greeting();
                    greeting.Salutation = "Hello World!";
                    channel.Send(greeting);
                    Console.WriteLine("Sent message {0}", greeting.Salutation);

                    Task.Delay(TimeSpan.FromMilliseconds(1000)).Wait();
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
