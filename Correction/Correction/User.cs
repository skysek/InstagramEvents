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
            if (String.IsNullOrEmpty(username)) throw new ArgumentException();
            _username = username;
            _isLive = false;
            _posts = new List<Post>();
            _followers = new List<User>();
            _followings = new List<User>();
            _messenger = new Messenger(this);
            _notifications = new List<Notification>();
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
        public List<Notification> Notifications => _notifications;
        public List<User> Blacklist => _blacklist;

        public void Follow(User user)
        {
            if (user.Blacklist.Contains(this))
            {
                throw new ArgumentException("Impossible de follow cet utilisateur.");
            }
            else
            {
                if (user != this)
                {
                    _followings.Add(user);
                    user.Followers.Add(this);
                    _notifEvent.NotifFollow(this, user);
                }
                else
                {
                    throw new ArgumentException("Impossible de se follow soi-même.");
                }
                
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
            if (post.Poster == this)
            {
                _posts.Remove(post);
            }
            else
            {
                throw new ArgumentException("Vous ne pouvez pas supprimer les posts d'autres utilisateurs.");
            }
        }

        public Like LikePost(Post post)
        {
            if (post.Poster.Blacklist.Contains(this))
            {
                throw new ArgumentException("Impossible de liker ce post.");
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
                throw new ArgumentException("Impossible de liker ce commentaire.");
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
                throw new ArgumentException("Impossible de commenter ce post.");
            }
            else
            {
                Comment c = post.AddComment(this, msg);
                _notifEvent.Comment(this, post, msg);
                return c;
            }
            
        }

        public void DeleteComment(Post post, Comment comment)
        {
            if (comment.Poster == this)
            {
                post.DeleteComment(comment);
            }
            else
            {
                throw new ArgumentException("Vous ne pouvez pas supprimer les commentaires d'autres utilisateurs.");
            }
        }

        public Comment Answer(Comment comment, string msg)
        {
            if (comment.Poster.Blacklist.Contains(this))
            {
                throw new ArgumentException("Impossible de répondre à ce commentaire.");
            }
            else
            {
                Comment c = comment.AddAnswer(this, msg);
                _notifEvent.Answer(this, comment, msg);
                return c;
            }
            
        }

        public void DeleteAnswer(Comment comment, Comment answer)
        {
            if (answer.Poster == this)
            {
                comment.DeleteAnswer(answer);
            }
            else
            {
                throw new ArgumentException("Vous ne pouvez pas supprimer les réponses d'autres utilisateurs.");
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
            if (user != this)
            {
                _blacklist.Add(user);
                this.Unfollow(user);
            }
            else
            {
                throw new ArgumentException("Impossible de se bloquer soi-même.");
            }
        }

        public void SendMessage(User receiver, string msg)
        {
            if (receiver.Blacklist.Contains(this))
            {
                throw new ArgumentException("Impossible d'envoyer un message à cet utilisateur.");
            }
            else
            {
                Conversation c = this.Messenger.AddConversation(receiver);

                Message m = c.AddMessage(this, msg);

                _notifEvent.SendMessage(receiver, m);
            }

        }

        public void DeleteMessage(Conversation conv, Message m)
        {
            if (conv.Sender == this)
            {
                conv.DeleteMessage(m);
            }
            else
            {
                throw new ArgumentException("Vous ne pouvez pas supprimer les messages d'autres conversations.");
            }
        }

        public Notification AddNotification(User sender, string message)
        {
            if (sender.Equals(null) || message.Equals(null) || message.Equals("")) throw new ArgumentException();
            int idx = _notifications.Count + 1;
            Notification n = new Notification(idx, sender, this, message);
            _notifications.Add(n);
            return n;
        }

        public void DeleteNotification(Notification notification)
        {
            if (notification.Receiver == this)
            {
                _notifications.Remove(notification);
            }
            else
            {
                throw new ArgumentException("Vous ne pouvez pas supprimer les notifications d'autres utilisateurs.");
            }
            
        }
    }
}
