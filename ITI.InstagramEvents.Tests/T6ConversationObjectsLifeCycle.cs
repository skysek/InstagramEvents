using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;

namespace ITI.InstagramEvents.Tests
{
    [TestFixture]
    class T6ConversationObjectsLifeCycle
    {

        [Test]
        public void t1_adding_conversation_should_be_reciprocal_between_users()
        {
            User u1 = new User( "Alex1234" );
            User u2 = new User( "Loic5678" );

            Conversation c = u1.Messenger.AddConversation( u2 );

            u1.Messenger.Conversations.Should().Contain( c );
            c.Sender.Should().Be( u1 );
            c.Receiver.Should().Be( u2 );

            Conversation conv = u2.Messenger.FindConversation(c.Receiver, c.Sender);
            conv.Should().NotBeNull();
        }

        [Test]
        public void t2_sending_message_should_update_both_conversations()
        {
            User u1 = new User( "Alex1234" );
            User u2 = new User( "Loic5678" );

            u1.SendMessage( u2, "Hello !" );
            Conversation c_u1 = u1.Messenger.FindConversation(u1, u2);
            Conversation c_u2 = u2.Messenger.FindConversation(u2, u1);

            u1.Messenger.Conversations.Should().Contain( c_u1 );
            u2.Messenger.Conversations.Should().Contain( c_u2 );

            Message m1 = c_u1.Messages.First();
            Message m2 = c_u2.Messages.First();

            m1.Should().NotBeNull();
            m2.Should().NotBeNull();

            m1.Poster.Should().Be( u1 );
            m2.Poster.Should().Be( u1 );
        }

        [Test]
        public void t3_message_deletion_should_be_possible_by_conversation_sender_only()
        {
            User u1 = new User( "Alex1234" );
            User u2 = new User( "Loic5678" );

            u1.SendMessage( u2, "Hello !" );

            Conversation c_u1 = u1.Messenger.FindConversation(u1, u2);
            Conversation c_u2 = u2.Messenger.FindConversation(u2, u1);

            Message m1 = c_u1.Messages.First();
            Message m2 = c_u2.Messages.First();

            Assert.Throws<ArgumentException>( () => u1.DeleteMessage( c_u2, m2 ) );

            u1.DeleteMessage( c_u1, m1 );
            c_u1.Messages.Should().NotContain( m1 );
        }
    }
}
