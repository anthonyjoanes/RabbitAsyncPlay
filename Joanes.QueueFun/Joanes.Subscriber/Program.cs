using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;
using Joanes.Messages;

namespace Joanes.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.SubscribeAsync<TestMessage>(String.Empty, HandleTextMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static Task HandleTextMessage(TestMessage message)
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(new Random().Next(1000, 10000));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Got message {0}", message.Text);
                Console.ResetColor();
            });
        }
    }
}
