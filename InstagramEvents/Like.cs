using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramEvents
{
    public class Like
    {
        readonly User _liker;
        readonly Post _post;
        readonly Comment _comment;
        readonly Message _message;

        internal Like(User liker, dynamic content)
        {
            throw new NotImplementedException();
        }

        public User Liker
        {
            get { throw new NotImplementedException(); }
        }

        public Post Post
        {
            get { throw new NotImplementedException(); }
        }

        public Comment Comment
        {
            get { throw new NotImplementedException(); }
        }

        public Message Message
        {
            get { throw new NotImplementedException(); }
        }
    }
}
