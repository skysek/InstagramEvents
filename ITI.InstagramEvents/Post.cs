using System;
using System.Collections.Generic;
using System.Drawing;

namespace ITI.InstagramEvents
{
    public class Post
    {
        internal Post(int index, User poster, Image content, string description)
        {
            throw new NotImplementedException();
        }

        public int Index
        {
            get { throw new NotImplementedException(); }
        }

        public User Poster
        {
            get { throw new NotImplementedException(); }
        }

        public Image Content
        {
            get { throw new NotImplementedException(); }
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
        }

        public IReadOnlyList<Like> Likes
        {
            get { throw new NotImplementedException(); }
        }

        public IReadOnlyList<Comment> Comments
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime PostedAt
        {
            get { throw new NotImplementedException(); }
        }

        public Comment AddComment(User poster, string message)
        {
            throw new NotImplementedException();
        }

        public Like AddLike(User liker)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
