using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramEvents
{
    public class Message
    {
        internal Message(int idx, User sender, string content)
        {
            throw new NotImplementedException();
        }

        public int Index
        {
            get { throw new NotImplementedException(); }
        }

        public string Content
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime Posted_at
        {
            get { throw new NotImplementedException(); }
        }

        public User Sender
        {
            get { throw new NotImplementedException(); }
        }

        public List<Like> Likes
        {
            get { throw new NotImplementedException(); }
        }


        public Like AddLike(User liker)
        {
            throw new NotImplementedException();
        }
    }
}
