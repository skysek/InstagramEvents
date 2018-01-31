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

        public Like(User liker, dynamic content)
        {
            _liker = liker;
            if (content.GetType() == Post.GetType())
            {
                _post = content;
            }else if(content.GetType() == Comment.GetType())
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
