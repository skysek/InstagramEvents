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
        bool _isLive;
        readonly Messenger _messenger;
        readonly List<User> _blacklist;
        private NotifEvent _notifEvent;

        public User(string username)
        {
            if (String.IsNullOrEmpty(username)) throw new ArgumentException();
            _username = username;
            _isLive = false;
            _posts = new List<Post>();
            _followers = new List<User>();
            _followings = new List<User>();
            _messenger = new Messenger(this);
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
        public bool IsLive { get => _isLive; set => _isLive = value; }
        public Messenger Messenger => _messenger;
        public List<User> Blacklist => _blacklist;

        public void Follow(User user)
        {
            if (user.Blacklist.Contains(this))
            {
                throw new Exception("Impossible de follow cet utilisateur.");
            }
            else
            {
                _followings.Add(user);
                user.Followers.Add(this);
                _notifEvent.NotifFollow(this);
            }
        }

        public void Unfollow(User user)
        {
            _followings.Remove(user);
            user.Followers.Remove(this);
        }

        public Post AddPost(Image content, string description = "")
        {
            if (content.Equals(null) || description.Equals(null)) throw new NullReferenceException();
            int idx = _posts.Count + 1;
            Post p = new Post(idx, this, content, description);
            _posts.Add(p);
            return p;
        }

        public void DeletePost(Post post)
        {
            _posts.Remove(post);
        }

        public Like LikePost(Post post)
        {
            if (post.Poster.Blacklist.Contains(this))
            {
                throw new Exception("Impossible de liker ce post.");
            }
            else
            {
                Like l = post.AddLike(this);
                _notifEvent.LikePost(post, this);
                return l;
            }
        }

        public Like LikeComment(Comment comment)
        {
            if (comment.Poster.Blacklist.Contains(this))
            {
                throw new Exception("Impossible de liker ce commentaire.");
            }
            else
            {
                Like l = comment.AddLike(this);
                _notifEvent.LikeComment(comment, this);
                return l;
            }
            
        }

        public Comment Comment(Post post, string msg)
        {
            if (post.Poster.Blacklist.Contains(this))
            {
                throw new Exception("Impossible de commenter ce post.");
            }
            else
            {
                Comment c = post.AddComment(this, msg);
                _notifEvent.Comment(this, post, msg);
                return c;
            }
            
        }

        public Comment Answer(Comment comment, string msg)
        {
            if (comment.Poster.Blacklist.Contains(this))
            {
                throw new Exception("Impossible de répondre à ce commentaire.");
            }
            else
            {
                Comment c = comment.AddAnswer(this, msg);
                _notifEvent.Answer(this, comment, msg);
                return c;
            }
            
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

        public void BlockUser(User user)
        {
            _blacklist.Add(user);
            this.Unfollow(user);
        }

        public void SendMessage(User user, string msg)
        {
            if (user.Blacklist.Contains(this))
            {
                throw new Exception("Impossible d'envoyer un message à cet utilisateur.");
            }
            else
            {
                Conversation c = this.Messenger.AddConversation(user);
                Message m = c.AddMessage(this, msg);
                _notifEvent.SendMessage(user, m);
            }
            
        }
    }
}
