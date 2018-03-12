using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.InstagramEvents
{
    public class Message: ILikable
    {
        readonly int _index;
        readonly User _poster;
        readonly string _content;
        readonly DateTime _posted_at;
        readonly List<Like> _likes;
     
        internal Message(int idx, User poster, string content)
        {
            _index = idx;
            _poster = poster;
            _content = content;
            _posted_at = DateTime.Now;
            _likes = new List<Like>();
        }

        public int Index => _index;
        public string Content => _content;
        public DateTime Posted_at => _posted_at;
        public User Poster => _poster;
        public IReadOnlyList<Like> Likes => _likes;


        public Like AddLike(User liker)
        {
            Like l = new Like(liker, this);
            _likes.Add(l);
            return l;
        }
    }
}
