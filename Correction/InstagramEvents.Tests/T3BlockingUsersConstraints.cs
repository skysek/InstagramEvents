using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NUnit.Framework;
using FluentAssertions;

namespace InstagramEvents.Tests
{
    [TestFixture]
    class T3BlockingUsersConstraints
    {
    
        [Test]
        public void t1_blocked_user_can_not_follow_the_blocker_user()
        {
            User u1 = new User("Alex1234");
            User u2 = new User("Loic5678");
            u1.BlockUser(u2);
            
            Assert.Throws<Exception>(() => u2.Follow(u1));
        
        }

        [Test]
        public void t2_blocked_user_can_not_like_or_comment_anything_of_blocker_user()
        {
            User u1 = new User("Alex1234");
            User u2 = new User("Loic5678");

            u1.BlockUser(u2);

            Image img = new Bitmap(1, 1);
            Post p = u1.AddPost(img);

            Assert.Throws<Exception>(() => u2.LikePost(p));
            Assert.Throws<Exception>(() => u2.Comment(p, "comment"));

            Comment c = p.AddComment(u1, "Test");

            Assert.Throws<Exception>(() => u2.LikeComment(c));
            Assert.Throws<Exception>(() => u2.Answer(c, "answer"));
        }

        [Test]
        public void t3_blocked_user_cannot_send_message_to_blocker_user()
        {
            User u1 = new User("Alex1234");
            User u2 = new User("Loic5678");

            u1.BlockUser(u2);

            Assert.Throws<Exception>(() => u2.SendMessage(u1, "Hey"));
        }
    }
}
