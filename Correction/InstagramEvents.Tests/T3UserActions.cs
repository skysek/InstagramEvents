using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using System.Drawing;

namespace InstagramEvents.Tests
{
    [TestFixture]
    class T3UserActions
    {
        [Test]
        public void t1_users_can_follow_and_unfollow_other_users()
        {
            User u1 = new User("Alex1234");
            User u2 = new User("Loic5678");

            u1.Follow(u2);
            u1.Followings.Should().Contain(u2);
            u2.Followers.Should().Contain(u1);

            u1.Unfollow(u2);
            u1.Followings.Should().NotContain(u2);
            u2.Followers.Should().NotContain(u1);

            Assert.Throws<ArgumentException>(() => u1.Follow(u1));
        }

        [Test]
        public void t2_users_can_like_and_comment_posts_and_comments()
        {
            User u1 = new User("Alex1234");
            User u2 = new User("Loic5678");
            Image img = new Bitmap(1, 1);

            Post p = u1.AddPost(img);
            Like l = u2.LikePost(p);
            p.Likes.Should().Contain(l);

            Comment c = u2.Comment(p, "Test comment");
            p.Comments.Should().Contain(c);
        }

        [Test]
        public void t3_users_can_delete_their_comment_and_answer()
        {
            User u1 = new User("Alex1234");
            User u2 = new User("Loic5678");
            Image img = new Bitmap(1, 1);

            Post p = u1.AddPost(img); 

            Comment c1 = u1.Comment(p, "Test comment u1");
            Comment c2 = u2.Comment(p, "Test comment u2");

            Assert.Throws<ArgumentException>(() => u2.DeleteComment(p, c1));
            u1.DeleteComment(p, c1);
            p.Comments.Should().NotContain(c1);

            Comment a1 = u1.Answer(c2, "Test answer u1");
            Comment a2 = u2.Answer(c2, "Test answer u2");

            Assert.Throws<ArgumentException>(() => u2.DeleteAnswer(c2, a1));
            u1.DeleteAnswer(c2, a1);
            c2.Answers.Should().NotContain(a1);
        }

        [Test]
        public void t4_users_can_block_users()
        {
            User u1 = new User("Alex1234");
            User u2 = new User("Loic5678");

            u1.BlockUser(u2);
            u1.Blacklist.Should().Contain(u2);

            Assert.Throws<ArgumentException>(() => u1.BlockUser(u1));
        }
    }
}
