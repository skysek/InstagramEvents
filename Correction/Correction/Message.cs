using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramEvents
{
    public class Message
    {
        readonly int _index;
        readonly string _content;
        readonly DateTime _posted_at;

        internal Message()
        {
            throw new NotImplementedException();
        }

        public int Index
        {
            get { throw new NotImplementedException(); }
        }

        public string Content
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime Posted_at
        {
            get { throw new NotImplementedException(); }
        }
    }
}
