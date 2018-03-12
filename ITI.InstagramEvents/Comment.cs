using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ITI.InstagramEvents
{
    public class Comment: ILikableAndCommentable
    {
        internal Comment(int index, User poster, ILikableAndCommentable parent, string message)
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

        public ILikableAndCommentable ParentComment
        {
            get { throw new NotImplementedException(); }
        }

        public string Message
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

        public Like AddLike(User liker)
        {
            throw new NotImplementedException();
        }

        public Comment AddComment( User poster, string message )
        {
            throw new NotImplementedException();
        }

        public void DeleteComment( Comment answer )
        {
            throw new NotImplementedException();
        }
    }
}
