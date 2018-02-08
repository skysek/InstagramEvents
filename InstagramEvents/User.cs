using System;
using System.Collections.Generic;
using System.Drawing;

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
        bool _isLive;
        readonly Messenger _messenger;
        readonly List<Notification> _notifications;
        readonly List<User> _blacklist;
        private NotifEvent _notifEvent;

        public User(string username)
        {
            throw new NotImplementedException();
        }

         void _notifEvent_BeforeNotifEvent(string message)
        {
            Console.WriteLine($"BeforeNotifeEvent fires from {message}");
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

        public bool IsLive { get => _isLive; set => _isLive = value; }

        public Messenger Messenger
        {
            get { throw new NotImplementedException(); }
        }

        public List<Notification> Notifications
        {
            get { throw new NotImplementedException(); }
        }

        public List<User> Blacklist
        {
            get { throw new NotImplementedException(); }
        }

        public void Follow(User user)
        {
            throw new NotImplementedException();
        }

        public void Unfollow(User user)
        {
            throw new NotImplementedException();
        }

        public Post AddPost(Image content, string description = "")
        {
            throw new NotImplementedException();
        }

        public void DeletePost(Post post)
        {
            throw new NotImplementedException();
        }

        public Like LikePost(Post post)
        {
            throw new NotImplementedException();
        }

        public Like LikeComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Like LikeMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public Comment Comment(Post post, string msg)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(Post post, Comment comment)
        {
            throw new NotImplementedException();
        }

        public Comment Answer(Comment comment, string msg)
        {
            throw new NotImplementedException();
        }

        public void DeleteAnswer(Comment comment, Comment answer)
        {
            throw new NotImplementedException();
        }

        public void StartLive()
        {
            throw new NotImplementedException();
        }

        public void StopLive()
        {
            throw new NotImplementedException();
        }

        public void BlockUser(User user)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(User receiver, string msg)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(Conversation conv, Message m)
        {
            throw new NotImplementedException();
        }

        public Notification AddNotification(User sender, string message)
        {
            throw new NotImplementedException();
        }

        public void DeleteNotification(Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
