using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.InstagramEvents
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

        public IReadOnlyList<Conversation> Conversations => _conversations;

        public Conversation AddConversation(User receiver)
        {
            Conversation conv = new Conversation(_user, receiver);
            Conversation conv2 = new Conversation(receiver, _user);

            _conversations.Add(conv);
            receiver.Messenger.AddConversation(conv2);

            return conv;
        }

        public Conversation FindConversation(User sender, User receiver)
        {
            Conversation conversation = _conversations.Find( ( conv ) => conv.Sender == sender && conv.Receiver == receiver );
            return conversation;
        }

        public void AddConversation(Conversation conversation )
        {
            _conversations.Add( conversation );
        }

        public void DeleteConversation(Conversation conversation)
        {
            _conversations.Remove(conversation);
        }

    }
}
