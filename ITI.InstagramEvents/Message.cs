using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.InstagramEvents
{
    public class Message: ILikable
    {
        internal Message(int idx, User poster, string content)
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

        public User Poster
        {
            get { throw new NotImplementedException(); }
        }

        public IReadOnlyList<Like> Likes
        {
            get { throw new NotImplementedException(); }
        }


        public Like AddLike(User liker)
        {
            throw new NotImplementedException();
        }
    }
}
