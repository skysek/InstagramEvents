using System;
using System.Collections.Generic;
using System.Drawing;
using Correction;

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
        private NotifEvent _notifEvent;

        public User(string username)
        {
            if (String.IsNullOrEmpty(username)) throw new ArgumentException();
            _username = username;
            _isSignedUp = true;
            _isLive = false;
            _posts = new List<Post>();
            _followers = new List<User>();
            _followings = new List<User>();
            _messenger = new Messenger(this);
            _facebook_friends = new List<User>();
            _blacklist = new List<User>();
            _notifEvent = new NotifEvent();
            _notifEvent.BeforeNotifEvent += _notifEvent_BeforeNotifEvent;
        }

         void _notifEvent_BeforeNotifEvent(string message)
        {
            Console.WriteLine($"BeforeNotifeEvent fires from {message}");
        }

        public string Surname { get => _surname; set => _surname = value; }
        public string Name { get => _name; set => _name = value; }
        public string Username => _username;
        public string Website { get => _website; set => _website = value; }
        public string Biography { get => _biography; set => _biography = value; }
        public string Email { get => _email; set => _email = value; }
        public int Phone { get => _phone; set => _phone = value; }
        public List<Post> Posts => _posts;
        public List<User> Followers => _followers;
        public List<User> Followings => _followings;
        public bool IsSignedUp { get => _isSignedUp; set => _isSignedUp = value; }
        public bool IsLive { get => _isLive; set => _isLive = value; }
        public Messenger Messenger => _messenger;
        public List<User> Facebook_friends => _facebook_friends;
        public List<User> Blacklist => _blacklist;

        public void Follow(User user)
        {
            _followings.Add(user);
            user.Followers.Add(this);
           _notifEvent.NotifFollow(this);
        }

        public void Unfollow(User user)
        {
            _followings.Remove(user);
            user.Followers.Remove(this);
        }

        public Post AddPost(Image content, string description = null)
        {
            int idx = _posts.Count + 1;
            Post p = new Post(idx, this, content, description);
            _posts.Add(p);
            return p;
        }

        public void DeletePost(int idx)
        {
            Post rm = _posts.Find(p => p.Index.Equals(idx));
            _posts.Remove(rm);
        }

        public void LikePost(Post post, User user)
        {
            post.AddLike(this);
            _notifEvent.LikePost(post,user);
        }

        public void LikeComment(Comment comment)
        {
            comment.AddLike(this);
            _notifEvent.LikeComment(comment,this);
        }

        public void Comment(User user,Post post, string msg)
        {
            post.AddComment(this, msg);
           _notifEvent.Comment(user,post,msg);
        }

        public void Answer(User u,Comment comment, string msg)
        {
            comment.AddAnswer(this, msg);
            _notifEvent.Answer(u,comment,msg);
        }

        public void StartLive()
        {
            _isLive = true;
            _notifEvent.StartLive(this);
        }

        public void StopLive()
        {
           _isLive = false;
        }

        public void SendMessage(User user, string msg)
        {
            Conversation c = this.Messenger.AddConversation(user);
            Message m = c.AddMessage(this, msg);
            _notifEvent.SendMessage(user,m);
        }
    }
}
