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
    public class T2PostObjectsLifeCycle
    {

        [Test]
        public void t1_created_posts_should_have_nothing_but_index_poster_content_optional_description_and_date()
        {

            User u = new User("Alex1234");
            Image img = new Bitmap(1, 1);

            Post p = u.AddPost(img, "Test created post");

            Assert.Throws<NullReferenceException>(() => u.AddPost(null));
            Assert.Throws<NullReferenceException>(() => u.AddPost(img, null));

            p.Index.Should().NotBe(0);
            p.Poster.Should().Be(u);
            p.Content.Should().Should().NotBeNull();
            p.Description.Should().NotBeNull();
            p.Likes.Should().BeNullOrEmpty();
            p.Comments.Should().BeNullOrEmpty();
            p.Posted_at.Should().NotBe(new DateTime());
        }

        [Test]
        public void t2_posts_index_should_not_be_0_and_should_be_unique()
        {
            User u = new User("Alex1234");
            Image img = new Bitmap(1, 1);

            Post p1 = u.AddPost(img, "Test index 1");
            p1.Index.Should().NotBe(0);

            Post p2 = u.AddPost(img, "Test index 2");
            p2.Index.Should().NotBe(0);

            p1.Index.Should().NotBe(p2.Index);
        }

        [Test]
        public void t3_posts_are_created_by_user_with_optional_description()
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

    }
}
