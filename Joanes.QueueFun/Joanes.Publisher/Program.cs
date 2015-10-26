using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;
using Joanes.Messages;

namespace Joanes.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(5000);
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Enter a message. 'Quit' to quit.");

                for (var i = 0; i < 100; i++)
                {
                    bus.Publish(new TestMessage
                    {
                        Text = $"Message: {i}"
                    });
                }
            }
        }
    }
}
