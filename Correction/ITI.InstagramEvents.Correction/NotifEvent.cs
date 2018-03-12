using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.InstagramEvents
{
    public class NotifEvent
    {
        public delegate void BeforeNotif(string message);
        public event BeforeNotif BeforeNotifEvent;

        public NotifEvent()
        {
            
        }

        public void NotifFollow(User follower, User following)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("NotifFollow");
            following.AddNotification(follower, $"{follower.Username} a commencé à vous suivre");
        }

        public void LikePost(Post post, User u)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("LikePost");
            post.Poster.AddNotification(u, $" {u.Username} a aimé votre contenu {post.Description}");
        }

        public void LikeComment(Comment comment, User u)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("LikeComment");
            comment.Poster.AddNotification(u, $" {u.Username} a aimé votre commentaire : {comment.Message}");
        }

        public void LikeMessage(Message message, User u)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("LikeMessage");
            message.Poster.AddNotification(u, $" {u.Username} a aimé votre message : {message.Content}");
        }

        public void Comment(User user,Post post, String msg)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("Comment");
            post.Poster.AddNotification(user, $"{user.Username} a commenté votre post : {msg}");
        }

        public void Answer(User u, Comment comment, string msg)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("Answer");
            comment.Poster.AddNotification(u, $"{u.Username} a répondu à votre commentaire : {msg}");
        }

        public void StartLive(User user)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("StartLive");

            foreach (User u in user.Followers)
            {
                u.AddNotification(user, $"{user.Username} a commencé un live en direct");
            }
        }

        public void SendMessage(User receiver, Message m)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("SendMessage");
            receiver.AddNotification(m.Poster, $"{m.Poster.Username} vous a envoyé un nouveau message : {m.Content}");
        }
    }
}
