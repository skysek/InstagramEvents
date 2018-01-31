using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace InstagramEvents
{
    public class Comment
    {
        readonly User _poster;
        readonly Post _post;
        readonly Comment _comment;
        readonly string _message;
        readonly List<Like> _likes;
        readonly List<Comment> _answers;
        readonly DateTime _posted_at;

        public Comment(User poster, dynamic content, string message, List<Like> likes, List<Comment> answers, DateTime posted_at)
        {
            _poster = poster;
            if (content.GetType() == Post.GetType())
            {
                _post = content;
            }
            else if (content.GetType() == this.GetType())
            {
                _comment = content;
            }
            else
            {
                throw new ArgumentException();
            }
            _message = message;
            _likes = likes;
            _answers = answers;
            _posted_at = posted_at;
        }

        public User Poster => _poster;
        public Post Post => _post;
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
            Comment c = new Comment(poster, this, message, null, null, DateTime.Now);
            _answers.Add(c);
            return c;
        }

        public void Delete()
        {
            
        }

        public void Report()
        {
            
        }
    }
}
