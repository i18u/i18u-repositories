using i18u.Repositories.Mongo;
using i18u.Repositories.Tests.Mongo;
using NUnit.Framework;

namespace i18u.Repositories.Tests
{
    [TestFixture]
    public class MongoTests
    {
        [Test]
        public void AssertMongoConstructorWorks()
        {
            var mockClient = new MockClient();
            var mongoRepo = new MongoRepository<MockMongoEntity>(mockClient, "testDb", "testCollection");

        }
    }
}
