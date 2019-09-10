using i18u.Repositories.Mongo.Interop;

namespace i18u.Repositories.Tests.Mongo
{
    internal class MockClient : IMongoClient
    {
        public IMongoDatabase GetDatabase(string databaseName)
        {
            return new MockDatabase(databaseName);
        }
    }
}