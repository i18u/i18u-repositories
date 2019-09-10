namespace i18u.Repositories.Mongo.Interop
{
    /// <summary>
    /// A mongo database.
    /// </summary>
    public class MongoDatabase : IMongoDatabase
    {
        private MongoDB.Driver.IMongoDatabase _database;

        /// <summary>
        /// A mongo collection.
        /// </summary>
        /// <param name="collectionName">The name of the collection.</param>
        /// <typeparam name="T">The type of the collection's entities.</typeparam>
        /// <returns>The mongo collection.</returns>
        public IMongoCollection<T> GetCollection<T>(string collectionName) where T : IMongoModel
        {
            MongoDB.Driver.IMongoCollection<T> collection = _database.GetCollection<T>(collectionName);
            return new MongoCollection<T>(collection);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="MongoDatabase"/> class.
        /// </summary>
        /// <param name="database">The underlying <see cref="IMongoDatabase"/> class.</param>
        public MongoDatabase(MongoDB.Driver.IMongoDatabase database)
        {
            _database = database;
        }
    }
}