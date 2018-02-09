using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace InstagramEvents
{
    public class Comment
    {
        readonly int _index;
        readonly User _poster;
        readonly Post _post;
        readonly Comment _parent_comment;
        readonly string _message;
        readonly List<Like> _likes;
        readonly List<Comment> _answers;
        readonly DateTime _posted_at;

        internal Comment(int index, User poster, dynamic parent, string message)
        {
            _index = index;
            _poster = poster;
            if (parent.GetType() == typeof(Post))
            {
                _post = parent;
            }
            else if (parent.GetType() == typeof(Comment))
            {
                _parent_comment = parent;
            }
            else
            {
                throw new ArgumentException();
            }
            _message = message;
            _likes = new List<Like>();
            _answers = new List<Comment>();
            _posted_at = DateTime.Now;
        }

        public int Index => _index;
        public User Poster => _poster;
        public Post Post => _post;
        public Comment ParentComment => _parent_comment;
        public string Message => _message;
        public List<Like> Likes => _likes;
        public List<Comment> Answers => _answers;
        public DateTime PostedAt => _posted_at;

        public Like AddLike(User liker)
        {
            Like l = new Like(liker, this);
            _likes.Add(l);
            return l;
        }

        public Comment AddAnswer(User poster, String message)
        {
            int idx = _answers.Count + 1;
            Comment a = new Comment(idx, poster, this, message);
            _answers.Add(a);
            return a;
        }

        public void DeleteAnswer(Comment answer)
        {
            _answers.Remove(answer);
        }
    }
}
