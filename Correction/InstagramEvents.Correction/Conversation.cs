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

        internal Conversation(User sender, User receiver)
        {
            _sender = sender;
            _receiver = receiver;
            _messages = new List<Message>();
        }

        public User Sender => _sender;

        public User Receiver => _receiver;

        public List<Message> Messages => _messages;

        public Message AddMessage(User sender, string msg)
        {
            int idx = _messages.Count + 1;
            Message m = new Message(idx, sender, msg);
            _messages.Add(m);
            Conversation c = _receiver.Messenger.Conversations.Find((conv) => (conv.Sender == _receiver) && (conv.Receiver == sender));
            c.Messages.Add(m);

            return m;
        }

        public void DeleteMessage(Message message)
        {
            _messages.Remove(message);
        }
    }
}
