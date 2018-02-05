using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using FluentAssertions;

namespace InstagramEvents.Tests
{
    [TestFixture]
    public class T1UserObjectsLifeCycle
    {
        [Test]
        public void t1_creating_named_users()
        {
            Assert.Throws<ArgumentException>(() => new User(null));
            Assert.Throws<ArgumentException>(() => new User(String.Empty));
            
            {
                User u = new User("Alex1234");
                u.Username.Should().Equals("Alex1234");
            }
        }

        [Test]
        public void t2_created_users_should_have_nothing_but_username()
        {

            User u = new User("Alex1234");
            u.Name.Should().BeNull();
            u.Surname.Should().BeNull();
            u.Website.Should().BeNull();
            u.Biography.Should().BeNull();
            u.Email.Should().BeNull();
            u.Phone.Should().Be(0);
            u.Followers.Should().BeNullOrEmpty();
            u.Followings.Should().BeNullOrEmpty();
            u.Posts.Should().BeNullOrEmpty();
            u.Notifications.Should().BeNullOrEmpty();
            u.Blacklist.Should().BeNullOrEmpty();
            
        }

        [Test]
        public void t3_created_users_should_not_be_live_and_should_have_an_empty_messenger()
        {

            User u = new User("Alex1234");
            u.Messenger.Should().NotBeNull();
            u.Messenger.User.Should().Be(u);
            u.Messenger.Conversations.Should().BeNullOrEmpty();
            u.IsLive.Should().Equals(false);

        }

        [Test]
        public void t4_users_can_be_fullfilled()
        {
            User u = new User("Alex1234");
            u.Name = "Babeu";
            u.Surname = "Alexandre";
            u.Website = "http://www.testforproject.fr";
            u.Biography = "Young developer";
            u.Email = "babeu@intechinfo.fr";
            u.Phone = 0606060606;
            u.Name.Should().Be("Babeu");
            u.Surname.Should().Be("Alexandre");
            u.Website.Should().Be("http://www.testforproject.fr");
            u.Biography.Should().Be("Young developer");
            u.Email.Should().Be("babeu@intechinfo.fr");
            u.Phone.Should().Be(0606060606);
        }

        [Test]
        public void t5_users_can_add_and_delete_their_posts_only()
        {

            User u1 = new User("Alex1234");
            User u2 = new User("Loic5678");
            Image img = new Bitmap(1, 1);

            Post p = u1.AddPost(img, "Test created post");

            u1.Posts.Should().Contain(p);

            Assert.Throws<MethodAccessException>(() => u2.DeletePost(p));

            u1.DeletePost(p);

            u1.Posts.Should().NotContain(p);

        }
    }
}