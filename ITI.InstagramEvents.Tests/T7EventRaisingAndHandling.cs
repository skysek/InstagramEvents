using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace ITI.InstagramEvents.Tests
{
    [TestFixture]
    public class T7EventRaisingAndHandling
    {
        [Test]
        public void t1_follow_an_user_trigger_an_event()
        {
            User u1 = new User( "LoicD" );
            User u2 = new User( "AlexS" );
            User u3 = new User( "Pouloulou" );

            u2.Follow( u1 );
            u3.Follow( u1 );

            u1.Notifications[0].Message.Should().Contain( $"{u2.Username} a commencé à vous suivre" );
            u1.Notifications[1].Message.Should().Contain( $"{u3.Username} a commencé à vous suivre" );
            u1.Notifications.Count.Should().Be( 2 );
        }

        [Test]
        public void t2_send_a_message_to_an_user_trigger_an_event()
        {
            NotifEvent notifEvent = new NotifEvent();
            User u1 = new User( "LoicD" );
            User u2 = new User( "AlexS" );
            User u3 = new User( "Pouloulou" );

            u1.SendMessage( u2, "Le bando" );

            u2.Notifications[0].Message.Should().Contain( $"{u1.Username} vous a envoyé un nouveau message : {u2.Messenger.Conversations[0].Messages[0].Content}" );
            u2.Notifications.Count.Should().Be( 1 );
        }

        [Test]
        public void t3_like_a_post_trigger_an_event()
        {
            User u1 = new User( "LoicD" );
            User u2 = new User( "Kévin" );
            Image i = new Bitmap( 1, 1 );
            Post p = u1.AddPost( i, "Golden moments" );

            u2.LikePost( p );

            u1.Notifications[0].Message.Should().Contain( $"{u2.Username} a aimé votre contenu {p.Description}" );
            u1.Notifications.Count.Should().Be( 1 );
            u1.Notifications[0].Receiver.Should().BeEquivalentTo( u1 );
        }

        [Test]
        public void t4_like_a_comment_trigger_an_event()
        {
            User u1 = new User( "LoicD" );
            User u2 = new User( "KévinD" );
            u2.Surname = "Pouloulou";
            u1.Surname = "Lolo";
            Image i = new Bitmap( 1, 1 );
            Post p = u1.AddPost( i, "Golden moments" );

            u2.Comment( p, "yolo" );
            u1.LikeComment( p.Comments[0] );

            u2.Notifications[0].Message.Should().Contain( $"{u1.Username} a aimé votre commentaire : {p.Comments[0].Message}" );
            u2.Notifications.Count.Should().Be( 1 );
        }

        [Test]
        public void t5_comment_a_post_trigger_an_event()
        {
            User u1 = new User( "LoicD" );
            User u2 = new User( "KévinD" );
            u2.Surname = "Pouloulou";
            u1.Surname = "Lolo";
            Image i = new Bitmap( 1, 1 );
            Post p = u1.AddPost( i, "Golden moments" );

            u2.Comment( p, "beautiful" );

            u1.Notifications[0].Message.Should().Contain( $"{u2.Username} a commenté votre post : {p.Comments[0].Message}" );
            u1.Notifications.Count.Should().Be( 1 );
        }

        [Test]
        public void t6_answer_a_comment_trigger_an_event()
        {
            User u1 = new User( "LoicD" );
            User u2 = new User( "KévinD" );
            u2.Surname = "Pouloulou";
            u1.Surname = "Lolo";
            Image i = new Bitmap( 1, 1 );
            Post p = u1.AddPost( i, "Golden moments" );

            u2.Comment( p, "beautiful" );
            u1.Answer( p.Comments[0], "Merci" );

            u2.Notifications[0].Message.Should().Contain( $"{u1.Username} a répondu à votre commentaire : {p.Comments[0].Comments[0].Message}" );
            u1.Notifications.Count.Should().Be( 1 );

        }

        [Test]
        public void t7_start_a_live_trigger_an_event()
        {
            User u1 = new User( "LoicD" );
            User u2 = new User( "KévinD" );
            User u3 = new User( "LauranneD" );

            u2.Follow( u1 );
            u3.Follow( u1 );
            u1.StartLive();

            u2.Notifications[0].Message.Should().Contain( $"{u1.Username} a commencé un live en direct" );
            u3.Notifications[0].Message.Should().Contain( $"{u1.Username} a commencé un live en direct" );
        }

        [Test]
        public void t8_like_a_message_trigger_an_event()
        {
            User u1 = new User( "LoicD" );
            User u2 = new User( "KévinD" );
            u2.Surname = "Pouloulou";
            u1.Surname = "Lolo";
            u1.SendMessage( u2, "Bitch" );
            u2.LikeMessage( u2.Messenger.Conversations[0].Messages[0] );
            u1.Notifications[0].Message.Should().Contain( $"{u2.Username} a aimé votre message : {u2.Messenger.Conversations[0].Messages[0].Content}" );
        }
    }
}
