using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.InstagramEvents
{
    public class Like
    {
        readonly User _liker;
        readonly ILikable _content;

        internal Like(User liker, ILikable content)
        {
            _liker = liker;
            _content = content;
        }

        public User Liker => _liker;
        public ILikable Content => _content;
    }
}
