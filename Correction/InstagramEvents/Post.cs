using System;
using System.Collections.Generic;
using System.Drawing;

namespace InstagramEvents
{
    public class Post
    {

        public Post(int index, User poster, Image content, string description = null)
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

        public List<Like> Likes
        {
            get { throw new NotImplementedException(); }
        }

        public List<Comment> Comments
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime Posted_at
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

        public void DeleteComment(int idx)
        {
            throw new NotImplementedException();
        }
    }
}
