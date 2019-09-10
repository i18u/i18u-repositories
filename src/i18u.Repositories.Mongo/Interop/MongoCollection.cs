using MongoDB.Driver;

namespace i18u.Repositories.Mongo.Interop
{
    internal class MongoCollection<T> : IMongoCollection<T> where T : IMongoModel
    {
        private readonly MongoDB.Driver.IMongoCollection<T> _collection;

        public MongoCollection(MongoDB.Driver.IMongoCollection<T> collection) 
        {
            _collection = collection;
        }

        public IFindFluent<T, T> Find(FilterDefinition<T> filter)
        {
            return _collection.Find(filter);
        }
    }
}