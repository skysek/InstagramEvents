using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ITI.InstagramEvents
{
    public class Comment: ILikableAndCommentable
    {
        readonly int _index;
        readonly User _poster;
        readonly ILikableAndCommentable _parent;
        readonly string _message;
        readonly List<Like> _likes;
        readonly List<Comment> _comments;
        readonly DateTime _posted_at;

        internal Comment(int index, User poster, ILikableAndCommentable parent, string message)
        {
            _index = index;
            _poster = poster;
            _parent = parent;
            _message = message;
            _likes = new List<Like>();
            _comments = new List<Comment>();
            _posted_at = DateTime.Now;
        }

        public int Index => _index;
        public User Poster => _poster;
        public ILikableAndCommentable Parent => _parent;
        public string Message => _message;
        public IReadOnlyList<Like> Likes => _likes;
        public IReadOnlyList<Comment> Comments => _comments;
        public DateTime PostedAt => _posted_at;

        public Like AddLike(User liker)
        {
            Like l = new Like(liker, this);
            _likes.Add(l);
            return l;
        }

        public Comment AddComment(User poster, string message)
        {
            int idx = _comments.Count + 1;
            Comment a = new Comment(idx, poster, this, message);
            _comments.Add(a);
            return a;
        }

        public void DeleteComment(Comment answer)
        {
            _comments.Remove(answer);
        }
    }
}
