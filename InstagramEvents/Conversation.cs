using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramEvents
{
    public class Conversation
    {
        internal Conversation(User sender, User receiver)
        {
            throw new NotImplementedException();
        }

        public User Sender
        {
            get { throw new NotImplementedException(); }
        }

        public User Receiver
        {
            get { throw new NotImplementedException(); }
        }

        public List<Message> Messages
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime Last_message_at
        {
            get { throw new NotImplementedException(); }
        }

        public Message AddMessage(User sender, string msg)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
