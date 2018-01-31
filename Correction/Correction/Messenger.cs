using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramEvents
{
    public class Messenger
    {
        readonly User _user;
        readonly List<Conversation> _conversations;

        internal Messenger(User user)
        {
            _user = user;
            _conversations = new List<Conversation>();
        }

        public User User => _user;

        public List<Conversation> Conversations => _conversations;

        public Conversation AddConversation(User receiver)
        {
            Conversation conv = new Conversation(_user, receiver);
            return conv;
        }

        public void DeleteConversation(User receiver)
        {
            Conversation rm = _conversations.Find(c => c.Receiver.Equals(receiver));
            _conversations.Remove(rm);
        }

    }
}
