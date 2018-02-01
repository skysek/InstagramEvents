using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramEvents;

namespace Correction
{
    public class NotifEvent
    {
        public delegate void BeforeNotif();
        public event BeforeNotif BeforeNotifEvent;

        public NotifEvent()
        {
            
        }

        public void NotifFollow(User user)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent();
            Console.WriteLine($"{user.Username} a commencé à vous suivre");
        }

        public void LikePost(Post post)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent();
            Console.WriteLine($"{post.Poster} a aimé votre contenu {post.Description}");
        }

        public void LikeComent(Comment comment)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent();
            Console.WriteLine($"{comment.Poster.Username} a aimé votre contenu : {comment.Message}");
        }

        public void Comment(Post post, String msg)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent();
            Console.WriteLine($"{post.Poster.Username} a commenté votre post : {msg}");
        }

        public void Answer(Comment comment, string msg)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent();
            Console.WriteLine($"{comment.Poster.Username} a répondu à votre commantaire : {msg}");
            Console.WriteLine($"{comment.Post.Poster.Username} un commentaire a été posté sur votre post : {msg}");
        }

        public void StartLive(User user)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent();
            foreach (User u in user.Followers)
            {
                Console.WriteLine($"{u.Username} : {user.Username} a commencé un live en direct.");
            }
        }

        public void SendMessage(User user, Message m)
        {
            if (BeforeNotifEvent != null) BeforeNotifEvent();
            Console.WriteLine($"{m.Sender.Username} vous a envoyé un nouveau message");
        }
    }
}
