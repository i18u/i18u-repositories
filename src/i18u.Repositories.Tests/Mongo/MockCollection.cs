using MongoDB.Driver;

namespace i18u.Repositories.Mongo.Interop
{
    internal class MockCollection<T> : IMongoCollection<T> where T : IMongoModel
    {
        public IFindFluent<T, T> Find(FilterDefinition<T> filter)
        {
            
        }
    }
}