using i18u.Repositories.Mongo;
using i18u.Repositories.Mongo.Interop;

namespace i18u.Repositories.Tests.Mongo
{
    internal class MockDatabase : IMongoDatabase
    {
        public IMongoCollection<T> GetCollection<T>(string collectionName) where T : IMongoModel
        {
            return new MockCollection(collectionName);
        }
    }
}