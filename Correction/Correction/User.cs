using System;
using System.Collections.Generic;

namespace InstagramEvents
{
    public class User
    {
        string _surname;
        string _name;
        readonly string _username;
        string _website;
        string _biography;
        string _email;
        int _phone;
        readonly List<Post> _posts;
        readonly List<User> _followers;
        readonly List<User> _followings;
        bool _isSignedUp;
        bool _isLive;
        readonly Messenger _messenger;
        readonly List<User> _facebook_friends;
        readonly List<User> _blacklist;

        public User( string username )
        {
            throw new NotImplementedException();
        }

        public string Surname
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Username
        {
            get { throw new NotImplementedException(); }
        }

        public string Website
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Biography
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Email
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int Phone
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public List<Post> Posts
        {
            get { throw new NotImplementedException(); }
        }

        public List<User> Followers
        {
            get { throw new NotImplementedException(); }
        }

        public List<User> Followings
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSignedUp
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string IsLive
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Messenger Messenger
        {
            get { throw new NotImplementedException(); }
        }

        public List<User> Facebook_friends
        {
            get { throw new NotImplementedException(); }
        }

        public List<User> Blacklist
        {
            get { throw new NotImplementedException(); }
        }

        public User Find(string username)
        {
            throw new NotImplementedException();
        }

        public void Follow(string username)
        {
            throw new NotImplementedException();
        }

        public void Unfollow(string username)
        {
            throw new NotImplementedException();
        }

        public void LikePost(int postIndex)
        {
            throw new NotImplementedException();
        }

        public void LikeComment(int commentIndex)
        {
            throw new NotImplementedException();
        }

        public void Comment(int postIndex)
        {
            throw new NotImplementedException();
        }

        public void Answer(int commentIndex)
        {
            throw new NotImplementedException();
        }
    }
}
