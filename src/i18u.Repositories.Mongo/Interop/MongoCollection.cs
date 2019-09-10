using MongoDB.Driver;

namespace i18u.Repositories.Mongo.Interop
{
	/// <inheritdoc cref="IMongoCollection{T}" />
	internal class MongoCollection<T> : IMongoCollection<T> where T : IMongoModel
    {
	    /// <summary>
	    /// The <see cref="MongoDB.Driver.IMongoCollection{T}"/> to use.
	    /// </summary>
        private readonly MongoDB.Driver.IMongoCollection<T> _collection;

	    /// <summary>
	    /// Creates a new instance of the <see cref="MongoCollection{T}" /> class.
	    /// </summary>
	    /// <param name="collection">The underlying <see cref="MongoDB.Driver.IMongoCollection{T}"/> instance.</param>
        public MongoCollection(MongoDB.Driver.IMongoCollection<T> collection)
        {
            _collection = collection;
        }

	    /// <inheritdoc />
	    public IFindFluent<T, T> Find(FilterDefinition<T> filter)
        {
            return new FindFluent<T, T>(_collection.Find(filter));
        }
    }
}
