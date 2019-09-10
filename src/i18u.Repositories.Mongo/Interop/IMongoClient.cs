namespace i18u.Repositories.Mongo.Interop
{
    /// <summary>
    /// A connection to MongoDB.
    /// </summary>
    public interface IMongoClient
    {
        /// <summary>
        /// Retrieves a database object with the given name.
        /// </summary>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>The <see cref="IMongoDatabase"/> object.</returns>
        IMongoDatabase GetDatabase(string databaseName);
    }
}
