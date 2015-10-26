using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;

namespace Joanes.Messages
{
    [Queue("TestMessagesQueue", ExchangeName = "MyTestExchange")]
    public class TestMessage
    {
        public string Text { get; set; }
    }
}
