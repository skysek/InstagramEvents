using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace InstagramEvents
{
    public class Comment
    {
        internal Comment(int index, User poster, dynamic parent, string message)
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

        public Post Post
        {
            get { throw new NotImplementedException(); }
        }

        public Comment ParentComment
        {
            get { throw new NotImplementedException(); }
        }

        public string Message
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

        public DateTime PostedAt
        {
            get { throw new NotImplementedException(); }
        }

        public Comment AddLike(User liker)
        {
            throw new NotImplementedException();
        }

        public Comment AddAnswer(User poster, String message)
        {
            throw new NotImplementedException();
        }

        public void DeleteAnswer(Comment answer)
        {
            throw new NotImplementedException();
        }
    }
}
