using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramEvents
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
            Console.WriteLine($"{follower.Username} a commencé à vous suivre");
        }

        public void LikePost(Post post, User u)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("LikePost");
            post.Poster.AddNotification(u, $" {u.Username} a aimé votre contenu {post.Description}");
            Console.WriteLine($" {u.Username} a aimé votre contenu {post.Description}");
        }

        public void LikeComment(Comment comment, User u)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("LikeComment");
            comment.Poster.AddNotification(u, $" {u.Username} a aimé votre commentaire : {comment.Message}");
            Console.WriteLine($"{u.Username} a aimé votre commentaire : {comment.Message}");
        }

        public void Comment(User user,Post post, String msg)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("Comment");
            post.Poster.AddNotification(user, $"{user.Username} a commenté votre post : {msg}");
            Console.WriteLine($"{user.Username} a commenté votre post : {msg}");
        }

        public void Answer(User u, Comment comment, string msg)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("Answer");
            comment.Poster.AddNotification(u, $"{u.Username} a répondu à votre commentaire : {msg}");
            Console.WriteLine($"{u.Username} a répondu à votre commantaire : {msg}");
        }

        public void StartLive(User user)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("StartLive");

            foreach (User u in user.Followers)
            {
                u.AddNotification(user, $"{user.Username} a commencé un live en direct.");
                Console.WriteLine($"{user.Username} a commencé un live en direct.");
            }
        }

        public void SendMessage(User receiver, Message m)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("SendMessage");
            m.Sender.Messenger.AddConversation(receiver);
            Console.WriteLine($" {receiver.Surname} : {m.Sender.Username} vous a envoyé un nouveau message : {m.Content}");
        }
    }
}
