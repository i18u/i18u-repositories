using i18u.Repositories.Mongo;
using MongoDB.Bson;

namespace i18u.Repositories.Tests.Mongo
{
    class MockMongoEntity : IMongoModel
    {
        public ObjectId Id { get; set; }
    }
}