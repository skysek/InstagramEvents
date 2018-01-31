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

        internal Message(int idx, User sender, string content)
        {
            _index = idx;
            _sender = sender;
            _content = content;
            _posted_at = DateTime.Now;
        }

        public int Index => _index;

        public string Content => _content;

        public DateTime Posted_at => _posted_at;

        public User Sender => _sender;
    }
}
