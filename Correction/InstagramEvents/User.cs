using System;
using System.Collections.Generic;
using System.Drawing;

namespace InstagramEvents
{
    public class User
    {

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

        public string IsLive
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Messenger Messenger
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

        public Post AddPost(Image content, string description)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(Post post)
        {
            throw new NotImplementedException();
        }

        public void LikePost(Post post)
        {
            throw new NotImplementedException();
        }

        public void LikeComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void Comment(Post post, string msg)
        {
            throw new NotImplementedException();
        }

        public void Answer(Comment comment, string msg)
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
    }
}
