using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace InstagramEvents
{
    public class Comment
    {
        public User _poster;
        public String _message;
        public User _like;
        public Comment _answer;
        public DateTime _postedDate;

        public Comment(User poster, String message, User like, Comment answer, DateTime postedDate)
        {
            _poster = poster;
            _message = message;
            _like = like;
            _answer = answer;
            _postedDate = postedDate;
        }

        public User Poster => _poster;
        public String Message => _message;
        public User Like => _like;
        public Comment Answer => _answer;
        public DateTime PostDate => _postedDate;

        public Comment Add(User poster, String message)
        {
            Comment c = new Comment(poster,message,null,null,DateTime.Now);
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
