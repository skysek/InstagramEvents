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
    class T3LikeAndCommentObjectsBehavior
    {

        [Test]
        public void t1_created_comments_should_have_only_index_poster_parent_message_and_date()
        {

            User u = new User("Alex1234");
            Image img = new Bitmap(1, 1);

            Post p = u.AddPost(img, "Test creation likes and comments");
            Comment c = p.AddComment(u, "test creation comment");

            c.Index.Should().NotBe(0);
            c.Poster.Should().Be(u);
            c.Post.Should().Be(p);
            c.Message.Should().Be("test creation comment");

            c.Likes.Should().BeNullOrEmpty();
            c.Answers.Should().BeNullOrEmpty();
            c.PostedAt.Should().NotBe(new DateTime());

        }
        [Test]
        public void t2_comments_index_should_not_be_0_and_should_be_unique_for_each_parent()
        {
            User u = new User("Alex1234");
            Image img = new Bitmap(1, 1);

            Post p = u.AddPost(img, "Test comment index");
            Comment c1 = p.AddComment(u, "Test index comment 1");
            c1.Index.Should().NotBe(0);

            Comment c2 = p.AddComment(u, "Test index comment 2");
            c2.Index.Should().NotBe(0);

            c1.Index.Should().NotBe(c2.Index);

            Comment a1 = c1.AddAnswer(u, "Test index answer 1");
            a1.Index.Should().NotBe(0);

            Comment a2 = c1.AddAnswer(u, "Test index answer 2");
            a1.Index.Should().NotBe(0);

            a1.Index.Should().NotBe(a2.Index);
        }

        [Test]
        public void t3_likes_and_comments_should_be_attributed_to_posts_or_comments()
        {
            User u = new User("Alex1234");

            Image img = new Bitmap(1, 1);
            Post p = u.AddPost(img);
            Like l = p.AddLike(u);

            l.Liker.Should().Be(u);
            l.Post.Should().Be(p);
            l.Comment.Should().BeNull();

            Comment c = p.AddComment(u, "test comment");

            c.Poster.Should().Be(u);
            c.Post.Should().Be(p);
            c.ParentComment.Should().BeNull();
        }

        [Test]
        public void t4_comments_are_deleted_by_respective_parent()
        {

            User u = new User("Alex1234");
            Image img = new Bitmap(1, 1);

            Post p = u.AddPost(img, "Test created post");
            Comment c = p.AddComment(u, "test add/delete comment to a post");

            p.Comments.Should().Contain(c);

            p.DeleteComment(c);

            p.Comments.Should().NotContain(c);

            Comment a = c.AddAnswer(u, "test add/delete answer to a comment");

            c.Answers.Should().Contain(a);

            c.DeleteAnswer(a);

            c.Answers.Should().NotContain(a);

        }

    }
}
