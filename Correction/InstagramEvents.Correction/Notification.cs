using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramEvents
{
    public class Notification
    {
        readonly int _index;
        readonly User _sender;
        readonly User _receiver;
        readonly string _message;
        readonly DateTime _receivedAt;

        internal Notification(int index, User sender, User receiver, string message)
        {
            _index = index;
            _sender = sender;
            _receiver = receiver;
            _message = message;
            _receivedAt = DateTime.Now;
        }

        public int Index => _index;

        public User Sender => _sender;

        public User Receiver => _receiver;

        public string Message => _message;

        public DateTime ReceivedAt => _receivedAt;
    }
}
