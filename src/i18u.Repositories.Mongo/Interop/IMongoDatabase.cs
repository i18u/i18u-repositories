namespace i18u.Repositories.Mongo.Interop
{
    /// <summary>
    /// Represents a mongo database.
    /// </summary>
    public interface IMongoDatabase
    {
        /// <summary>
        /// Retrieves the collection object from Mongo.
        /// </summary>
        /// <param name="collectionName">The name of the collection to retrieve.</param>
        /// <typeparam name="T">The type of entity stored in the collection.</typeparam>
        /// <returns>The <see cref="IMongoCollection{T}"/> instance.</returns>
        IMongoCollection<T> GetCollection<T>(string collectionName) where T : IMongoModel;
    }
}
