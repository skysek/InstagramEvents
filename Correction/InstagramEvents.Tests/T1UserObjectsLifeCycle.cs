using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
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
                Assert.That(u.Username, Is.EqualTo("Alex1234"));
                u.Messenger.Should().NotBeNull();
            }
        }

        [Test]
        public void t2_fullfill_users_informations()
        {
            User u = new User("Alex1234");
            u.Name = "Babeu";
            u.Surname = "Alexandre";
            u.Website = "http://www.testforproject.fr";
            u.Biography = "Young developer";
            u.Email = "babeu@intechinfo.fr";
            u.Phone = 0606060606;
            u.Name.Should().Equals("Babeu");
            u.Surname.Should().Equals("Alexandre");
            u.Website.Should().Equals("http://www.testforproject.fr");
            u.Surname.Should().Equals("Young developer");
            u.Surname.Should().Equals("babeu@intechinfo.fr");
            u.Surname.Should().Equals(0606060606);
        }

        [Test]
        public void t3_creating_posts_with_content_and_or_description()
        {

        }
    }
}