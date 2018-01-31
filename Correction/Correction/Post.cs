using System;
using System.Collections.Generic;
using System.Drawing;

namespace InstagramEvents
{
    public class Post
    {

        readonly int _index;
        readonly User _poster;
        readonly List<Image> _content;
        readonly string _description;
        readonly List<Like> _likes;
        readonly List<Comment> _comments;
        readonly DateTime _posted_at;

        public Post(List<Image> content, string description = null)
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

        public List<Image> Content
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
            Like l = new Like(liker, this);
            _likes.Add(l);
            return l;
        }

        public void DeleteComment(int idx)
        {
            throw new NotImplementedException();
        }


    }
}
