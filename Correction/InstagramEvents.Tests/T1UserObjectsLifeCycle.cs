﻿using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Correction;
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
        public void t5_posts_are_created_by_user_with_optional_description()
        {
            User u = new User("Alex1234");
            Image img = new Bitmap(1, 1);

            {
                Post p = u.AddPost(img);

                u.Posts.Should().Contain(p);
                p.Poster.Should().Be(u);
                p.Index.Should().NotBe(null);
                p.Index.Should().NotBe(0);
                p.Poster.Should().Be(u);
                p.Content.Should().Be(img);
                p.Description.Should().BeNullOrEmpty();
                p.Likes.Should().BeNullOrEmpty();
                p.Comments.Should().BeNullOrEmpty();
                p.Posted_at.Should().NotBe(new DateTime());
            }

            {
                Post p = u.AddPost(img, "My first image posted");

                u.Posts.Should().Contain(p);
                p.Index.Should().NotBe(null);
                p.Index.Should().NotBe(0);
                p.Poster.Should().Be(u);
                p.Content.Should().Be(img);
                p.Description.Should().Equals("My first image posted");
                p.Likes.Should().BeNullOrEmpty();
                p.Comments.Should().BeNullOrEmpty();
                p.Posted_at.Should().NotBe(new DateTime());
            }

        }

        [Test]
        public void t4_follow_an_user_trigger_an_event()
        {
            NotifEvent notifEvent = new NotifEvent();
            User u1 = new User("LoicD");
            User u2 = new User("AlexS");
            User u3 = new User("Pouloulou");
            u1.Name = "DONNE";
            u2.Name = "BABEU";
            u3.Name = "Reseaux";
            u2.Follow(u1);
            u3.Follow(u1);
            u1.StartLive();
        }

        [Test]
        public void t5_send_a_message_an_user_trigger_an_event()
        {
            NotifEvent notifEvent = new NotifEvent();
            User u1 = new User("LoicD");
            User u2 = new User("AlexS");
            User u3 = new User("Pouloulou");
            u1.Name = "DONNE";
            u2.Name = "BABEU";
            u3.Name = "Reseaux";
            u1.SendMessage(u2,"Le bando que du sale");
        }

    }
}