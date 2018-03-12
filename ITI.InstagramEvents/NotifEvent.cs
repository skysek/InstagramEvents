using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.InstagramEvents
{
    public class NotifEvent
    {
        public NotifEvent()
        {
            throw new NotImplementedException();
        }

        public void NotifFollow(User follower, User following)
        {
            throw new NotImplementedException();
        }

        public void LikePost(Post post, User u)
        {
            throw new NotImplementedException();
        }

        public void LikeComment(Comment comment, User u)
        {
            throw new NotImplementedException();
        }

        public void LikeMessage(Message message, User u)
        {
            throw new NotImplementedException();
        }

        public void Comment(User user,Post post, String msg)
        {
            throw new NotImplementedException();
        }

        public void Answer(User u, Comment comment, string msg)
        {
            throw new NotImplementedException();
        }

        public void StartLive(User user)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(User receiver, Message m)
        {
            throw new NotImplementedException();
        }
    }
}
