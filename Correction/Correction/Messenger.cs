﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramEvents
{
    public class Messenger
    {
        readonly int _index;
        readonly User _user;
        readonly List<Conversation> _conversations;

        internal Messenger()
        {
            throw new NotImplementedException();
        }

        public int Index
        {
            get { throw new NotImplementedException(); }
        }

        public User User
        {
            get { throw new NotImplementedException(); }
        }

        public List<Conversation> Conversations
        {
            get { throw new NotImplementedException(); }
        }

        public Conversation AddConversation(User otherUser)
        {
            throw new NotImplementedException();
        }

        public void DeleteConversation(int idx)
        {
            throw new NotImplementedException();
        }

    }
}
