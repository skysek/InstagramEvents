using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.InstagramEvents
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

        public IReadOnlyList<Conversation> Conversations
        {
            get { throw new NotImplementedException(); }
        }

        public Conversation FindConversation( User sender, User receiver )
        {
            throw new NotImplementedException();
        }

        public Conversation AddConversation(User receiver)
        {
            throw new NotImplementedException();
        }

        public void AddConversation( Conversation conversation )
        {
            throw new NotImplementedException();
        }

        public void DeleteConversation(Conversation conversation)
        {
            throw new NotImplementedException();
        }

    }
}
