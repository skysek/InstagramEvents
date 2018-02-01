using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramEvents
{
    public class Conversation
    {

        internal Conversation()
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

        public DateTime Last_Message_at
        {
            get { throw new NotImplementedException(); }
        }

        public Message AddMessage(string msg)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
