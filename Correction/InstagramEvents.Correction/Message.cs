using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramEvents
{
    public class Message
    {
        readonly int _index;
        readonly User _sender;
        readonly string _content;
        readonly DateTime _posted_at;
        readonly List<Like> _likes;
     
        internal Message(int idx, User sender, string content)
        {
            _index = idx;
            _sender = sender;
            _content = content;
            _posted_at = DateTime.Now;
            _likes = new List<Like>();
        }

        public int Index => _index;
        public string Content => _content;
        public DateTime Posted_at => _posted_at;
        public User Sender => _sender;
        public List<Like> Likes => _likes;


        public Like AddLike(User liker)
        {
            Like l = new Like(liker, this);
            _likes.Add(l);
            return l;
        }
    }
}
