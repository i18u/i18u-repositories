using System.Collections.Generic;
using i18u.Repositories.Mongo.Results;
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

		/// <inheritdoc />
		public void InsertOne(T model, bool bypassValidation)
		{
            var options = new InsertOneOptions
            {
				BypassDocumentValidation = bypassValidation
            };

            _collection.InsertOne(model, options);
        }

		/// <inheritdoc />
        public void InsertOne(T model)
        {
            InsertOne(model, false);
        }

        /// <inheritdoc />
        public void InsertMany(IEnumerable<T> entities, bool bypassValidation, bool isOrdered)
		{
            var insertManyOptions = new InsertManyOptions
            {
				BypassDocumentValidation = bypassValidation,
				IsOrdered = isOrdered,
            };

            _collection.InsertMany(entities, insertManyOptions);
		}

		/// <inheritdoc />
        public void InsertMany(IEnumerable<T> entities)
		{
            InsertMany(entities, false, false);
        }
    }
}
