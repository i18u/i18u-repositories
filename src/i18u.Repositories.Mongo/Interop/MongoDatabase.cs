namespace i18u.Repositories.Mongo.Interop
{
    /// <summary>
    /// A MongoDB database.
    /// </summary>
    internal class MongoDatabase : IMongoDatabase
    {
	    /// <summary>
	    /// The <see cref="MongoDB.Driver.IMongoDatabase"/> to use.
	    /// </summary>
        private readonly MongoDB.Driver.IMongoDatabase _database;

	    /// <inheritdoc />
	    public IMongoCollection<T> GetCollection<T>(string collectionName) where T : IMongoModel
        {
            MongoDB.Driver.IMongoCollection<T> collection = _database.GetCollection<T>(collectionName);
            return new MongoCollection<T>(collection);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="MongoDatabase"/> class.
        /// </summary>
        /// <param name="database">The underlying <see cref="MongoDB.Driver.IMongoDatabase"/> instance.</param>
        public MongoDatabase(MongoDB.Driver.IMongoDatabase database)
        {
            _database = database;
        }
    }
}
