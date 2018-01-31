using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;

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
                Assert.That(u.Name, Is.EqualTo("Alex1234"));
            }
        }

        [Test]
        public void t2_creating_posts_with_content_and_or_description()
        {
            
        }
    }
}
