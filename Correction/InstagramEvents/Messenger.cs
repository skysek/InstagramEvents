using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramEvents
{
    public class Messenger
    {

        internal Messenger(User user)
        {
            throw new NotImplementedException();
        }

        public User User
        {
            get { throw new NotImplementedException(); }
        }

        public List<Conversation> Conversations
        {
            get { throw new NotImplementedException(); }
        }

        public Conversation AddConversation(User receiver)
        {
            throw new NotImplementedException();
        }

        public void DeleteConversation(Conversation conversation)
        {
            throw new NotImplementedException();
        }

    }
}
