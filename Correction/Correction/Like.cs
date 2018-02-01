using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramEvents
{
    public class Like
    {
        readonly User _liker;
        Post _post;
        Comment _comment;

        internal Like(User liker, dynamic content)
        {
            _liker = liker;
            if (content.GetType() == typeof(Post))
            {
                _post = content;
            }else if(content.GetType() == typeof(Comment))
            {
                _comment = content;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public User Liker => _liker;
        public Post Post => _post;
        public Comment Comment => _comment;
    }
}
