using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramEvents
{
    public class Conversation
    {
        readonly User _sender;
        readonly User _receiver;
        readonly List<Message> _messages;
        readonly DateTime _last_message_at;

        internal Conversation(User sender, User receiver)
        {
            _sender = sender;
            _receiver = receiver;
            _messages = new List<Message>();
            _last_message_at = new DateTime();
        }

        public User Sender => _sender;

        public User Receiver => _receiver;

        public List<Message> Messages => _messages;

        public DateTime Last_message_at => _last_message_at;

        public Message AddMessage(User sender, string msg)
        {
            int idx = _messages.Count + 1;
            Message m = new Message(idx, sender, msg);
            return m;
        }

        public void DeleteMessage(int idx)
        {
            Message rm = _messages.Find(m => m.Index.Equals(idx));
            _messages.Remove(rm);
        }
    }
}
