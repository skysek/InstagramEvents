using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramEvents
{
    public class Like
    {
        public User _like;
        public Post _post;
        public Comment _comment;

        public Like(User like, Post post, Comment comment)
        {
            _like = like;
            _post = post;
            _comment = comment;
        }

        public User Likes => _like;
        public Post Posts => _post;
        public Comment Comments => _comment;
    }
}
