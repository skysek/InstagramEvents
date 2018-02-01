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
        readonly List<User> _blacklist;

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
            _followings.Add(user);
            user.Followers.Add(this);
            // Trigger un event
        }

        public void Unfollow(User user)
        {
            _followings.Remove(user);
            user.Followers.Remove(this);
            // Trigger un event
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
            Like l = post.AddLike(this);
            // Trigger un event
            return l;
        }

        public Like LikeComment(Comment comment)
        {
            Like l = comment.AddLike(this);
            // Trigger un event
            return l;
        }

        public Comment Comment(Post post, string msg)
        {
            Comment c = post.AddComment(this, msg);
            // Trigger un event
            return c;
        }

        public Comment Answer(Comment comment, string msg)
        {
            Comment c = comment.AddAnswer(this, msg);
            // Trigger un event
            return c;
        }

        public void StartLive()
        {
            _isLive = true;
            // Trigger un event
        }

        public void StopLive()
        {
            _isLive = false;
        }

        public void BlockUser(User user)
        {
            _blacklist.Add(user);
        }
    }
}
