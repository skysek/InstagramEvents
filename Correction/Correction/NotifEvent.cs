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

        public void NotifFollow(User user)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("NotifFollow");
            Console.WriteLine($"{user.Username} a commencé à vous suivre");
        }

        public void LikePost(Post post, User u)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("LikePost");
            Console.WriteLine($" {post.Poster.Username} : {u.Surname} a aimé votre contenu {post.Description}");
        }

        public void LikeComment(Comment comment, User u)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("LikeComment");
            Console.WriteLine($"{comment.Poster.Username} : {u.Surname} a aimé votre commentaire : {comment.Message}");
        }

        public void Comment(User user,Post post, String msg)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("Comment");
            Console.WriteLine($"{post.Poster.Username} : {user.Surname} a commenté votre post : {msg}");
        }

        public void Answer(User u, Comment comment, string msg)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("Answer");
            Console.WriteLine($"{u.Surname} a répondu à votre commantaire : {msg}");
            if (u.Surname != comment.Post.Poster.Surname)
            {
                Console.WriteLine($"{comment.Post.Poster.Username} un commentaire a été posté sur votre post : {msg}");
            }
        }

        public void StartLive(User user)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("StartLive");
            foreach (User u in user.Followers)
            {
                Console.WriteLine($"{u.Username} : {user.Username} a commencé un live en direct.");
            }
        }

        public void SendMessage(User user, Message m)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent("SendMessage");
            Console.WriteLine($" {user.Surname} : {m.Sender.Username} vous a envoyé un nouveau message : {m.Content}");
        }
    }
}
