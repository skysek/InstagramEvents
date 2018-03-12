using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.InstagramEvents
{
    public class Like
    {
        readonly User _liker;
        readonly ILikable _content;
        readonly Message _message;

        internal Like(User liker, ILikable content)
        {
            throw new NotImplementedException();
        }

        public User Liker
        {
            get { throw new NotImplementedException(); }
        }

        public ILikable Content
        {
            get { throw new NotImplementedException(); }
        }

        public Message Message
        {
            get { throw new NotImplementedException(); }
        }
    }
}
