using System;
using System.Collections.Generic;
using System.Drawing;

namespace InstagramEvents
{
    public class Post
    {

        readonly int _index;
        readonly User _poster;
        readonly Image _content;
        readonly string _description;
        readonly List<Like> _likes;
        readonly List<Comment> _comments;
        readonly DateTime _posted_at;

        internal Post(int index, User poster, Image content, string description = "")
        {
            if (content.Equals(null) || description.Equals(null)) throw new NullReferenceException();
            _index = index;
            _poster = poster;
            _content = content;
            _description = description;
            _likes = new List<Like>();
            _comments = new List<Comment>();
            _posted_at = DateTime.Now;
        }

        public int Index => _index;

        public User Poster => _poster;

        public Image Content => _content;

        public string Description => _description;

        public List<Like> Likes => _likes;

        public List<Comment> Comments => _comments;

        public DateTime Posted_at => _posted_at;

        public Comment AddComment(User poster, string message)
        {
            int idx = _comments.Count + 1;
            Comment c = new Comment(idx, poster, this, message);
            _comments.Add(c);
            return c;
        }

        public Like AddLike(User liker)
        {
            Like l = new Like(liker, this);
            Likes.Add(l);
            return l;
        }

        public void DeleteComment(int idx)
        {
            Comment rm = _comments.Find(c => c.Index.Equals(idx));
            _comments.Remove(rm);
        }
    }
}
